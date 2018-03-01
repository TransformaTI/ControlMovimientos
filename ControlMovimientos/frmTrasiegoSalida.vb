Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmTrasiegoSalida

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private Titulo As String


    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        lblKilos.Text = "0"
        lblRuta.Text = ""
        lblCamion.Text = ""
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboAlmacenOrigen.Text <> "" And CType(lblKilos.Text, Decimal) <> 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Registra la información en la base de datos
    Public Function RealizarMovimientos() As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            Cursor = Cursors.WaitCursor
            Dim Kilos As Decimal
            Dim Litros As Decimal

            Dim Ano As Integer

            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            Ano = dtpFMovimiento.Value.Year
            Kilos = CType(lblKilos.Text, Decimal)
            Litros = Kilos / CType(FactorDensidad, Decimal)
            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacenOrigen.Identificador, 0, 20, 0)

            'Registra el movimiento de salida
            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrigen.Identificador, dtpFMovimiento.Value, _
                                       Kilos, Litros, 20, dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            'Registra el detalle de los productos salida
            ProductoPanel.RegistraMovimientoProducto(cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador)
           
            If GLOBAL_Imprimir = "1" Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
                End If
            End If

            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            ProductoPanel.BorrarDatos()
            Cursor = Cursors.Default
        End If
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function ValidarRangoFechaVenta() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(0, cboAlmacenOrigen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
            dtpFVenta.Value = Fecha
            dtpFVenta.MinDate = CType(oConsultaFechas.drReader(1), Date)
            dtpFVenta.MaxDate = dtpFVenta.Value.AddDays(3)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = ValidarRangoFechaVenta()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Si el usuario tiene privilegios de realizar cargas de diferentes empresas, habilita el combo de las empresas 
    ' para que el usuario pueda relizar cargas de todas las empresas
    Private Sub HabilitarEmpresa()
        cboCorporativo.CargaDatos(0)
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)

        cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        ' Carga almacenes de tipo anden por CELULA
        cboAlmacenOrigen.CargaDatos(16, GLOBAL_Usuario, cboCelula.Identificador)
        '' Carga almaceens de tipo Ruta Portatil por CELULA
        'cboAlmacenDestino.CargaDatos(17, GLOBAL_Usuario, cboCelula.Identificador)
        'If (cboAlmacenDestino.Items.Count = 0) Or (cboAlmacenDestino.Items.Count > 1) Then
        '    ProductoPanel.BorrarDatos()
        'End If
        If cboAlmacenOrigen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenOrigen.Identificador)
            ValidarRangoFechaVenta()
        End If

        If GLOBAL_VerEmpresas = False Then
            cboCorporativo.Enabled = False
            ActiveControl = cboAlmacenOrigen
        End If
    End Sub

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora()
        Dim Impresoras As New Printing.PrinterSettings()
        rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
    End Sub

    ' Establece la conexion de los subreportes que esten contenidos en el reporte
    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer

        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)

                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = GLOBAL_Servidor
                        .DatabaseName = GLOBAL_BaseDatos
                        .UserID = GLOBAL_Usuario
                        .Password = GLOBAL_Password
                    End With
                    _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                Next
            End If
        Next
    End Sub

    ' Establece y realiza la conexión para cargar la información al reporte
    Public Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = GLOBAL_Servidor
                .DatabaseName = GLOBAL_BaseDatos
                .UserID = GLOBAL_Usuario
                .Password = GLOBAL_Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
        OpenSubreport()
    End Sub

    ' Manda al procedimientos los valores de los parametros e imprime el ticket de carga
    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketTrasiego.rpt")

            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Configuracion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@MovimientoAlmacen")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            AplicaInfoConexion()

            Try
                EstablecerImpresora()
                rptReporte.PrintToPrinter(1, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Inicialización de la forma
    Private Sub frmTrasiegoSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        HabilitarEmpresa()
        Titulo = "Salida por trasiego"
    End Sub

    ' Evento del boton btnCancelar, cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    
    ' Evento de cboAlmacenDestino, muestra los productos a ser cargados
    Private Sub cboAlmacenOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboAlmacenOrigen.SelectedIndexChanged
        If cboAlmacenOrigen.Focused Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim cRuta As New nombreRuta(0, cboAlmacenOrigen.Identificador)
            Dim cCamion As New nombreCamion(0, cboAlmacenOrigen.Identificador)
            cRuta.CargaDatos()
            lblRuta.Text = cRuta.Descripcion
            lblRuta.Tag = cRuta.Identificador
            cCamion.CargaDatos()
            lblCamion.Text = cCamion.Descripcion
            lblCamion.Tag = cCamion.Identificador

            HabilitarAceptar()
            If cboAlmacenOrigen.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenOrigen.Identificador)
                ValidarRangoFechaVenta()
            End If

            cRuta = Nothing
            cCamion = Nothing
            Cursor = Cursors.Default
        End If
    End Sub

    ' Evento del botón btnAceptar registra y valida la información de la carga
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ProductoPanel.VerificarExistencias(cboAlmacenOrigen.Identificador) Then
            RealizarMovimientos()
            ActiveControl = cboAlmacenOrigen
        Else
        Dim Mensajes As New PortatilClasses.Mensaje(1)
        MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ActiveControl = ProductoPanel.txtCantidad1
        End If
    End Sub

    ' Evento del botón cboAlmacenOrigen, llama a la que habilitará el boton de Aceptar
    Private Sub cboAlmacenOrigen_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles lblKilos.TextChanged, cboAlmacenOrigen.SelectedIndexChanged
        HabilitarAceptar()
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboAlmacenOrigen.KeyDown, dtpFMovimiento.KeyDown, dtpFVenta.KeyDown, _
    cboCorporativo.KeyDown, cboCelula.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        lblKilos.Text = Format(ProductoPanel.SumarKilos(), "n")
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento del control cboCorporativo en donde carga los almacenes correspondientes a la empresa seleccionada
    Private Sub cboCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativo.SelectedIndexChanged
        If cboCorporativo.Focused And cboCorporativo.Text <> "" Then
            Refresh()
            Cursor = Cursors.WaitCursor
            'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativo.Identificador, GLOBAL_Usuario)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
            ' Carga almacenes de tipo anden por CELULA
            cboAlmacenOrigen.CargaDatos(16, GLOBAL_Usuario, cboCelula.Identificador)

            If cboAlmacenOrigen.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenOrigen.Identificador)
                ValidarRangoFechaVenta()
            End If
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Focused And cboCelula.Text <> "" Then
            Cursor = Cursors.WaitCursor
            ' Carga almacenes de tipo anden por CELULA
            cboAlmacenOrigen.CargaDatos(16, GLOBAL_Usuario, cboCelula.Identificador)
            
            If cboAlmacenOrigen.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenOrigen.Identificador)
                ValidarRangoFechaVenta()

                Dim cRuta As New nombreRuta(0, cboAlmacenOrigen.Identificador)
                Dim cCamion As New nombreCamion(0, cboAlmacenOrigen.Identificador)
                cRuta.CargaDatos()
                lblRuta.Text = cRuta.Descripcion
                lblRuta.Tag = cRuta.Identificador
                cCamion.CargaDatos()
                lblCamion.Text = cCamion.Descripcion
                lblCamion.Tag = cCamion.Identificador
            End If
            Cursor = Cursors.Default
        End If
        HabilitarAceptar()
    End Sub

    Private Sub frmMovimientoAlmacen_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If cboAlmacenOrigen.Text <> "" Then
            Dim ofrmExistencias As New frmExistencias(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.Text)
            ofrmExistencias.ShowDialog()
            ofrmExistencias = Nothing
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(69)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class