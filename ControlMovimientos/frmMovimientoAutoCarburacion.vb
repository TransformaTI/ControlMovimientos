' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$007

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoAutoCarburacion
    Inherits System.Windows.Forms.Form

    Public TipoMovimiento As Short

    Private Producto As Integer
    Private FactorDensidad As String
    Private DatosSalvados As Boolean

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCamion As PortatilClasses.Combo.ComboCamion
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFAutoabasto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoAutoCarburacion))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCamion = New PortatilClasses.Combo.ComboCamion()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFAutoabasto = New System.Windows.Forms.DateTimePicker()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(513, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(513, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboCamion, Me.cboCorporativo, Me.Label2, Me.lblProducto, Me.lblLitros, Me.ProductoPanel, Me.cboAlmacen, Me.Label13, Me.Label6, Me.dtpFMovimiento, Me.Label7, Me.dtpFAutoabasto})
        Me.grpDatos.Location = New System.Drawing.Point(11, 14)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 298)
        Me.grpDatos.TabIndex = 13
        Me.grpDatos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Camión:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCamion
        '
        Me.cboCamion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCamion.Location = New System.Drawing.Point(130, 79)
        Me.cboCamion.Name = "cboCamion"
        Me.cboCamion.Size = New System.Drawing.Size(216, 21)
        Me.cboCamion.TabIndex = 2
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Location = New System.Drawing.Point(130, 24)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Empresa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(308, 270)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(35, 14)
        Me.lblProducto.TabIndex = 49
        Me.lblProducto.Text = "Litros:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLitros
        '
        Me.lblLitros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLitros.Location = New System.Drawing.Point(358, 265)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.Size = New System.Drawing.Size(120, 21)
        Me.lblLitros.TabIndex = 48
        Me.lblLitros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(8, 164)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(463, 90)
        Me.ProductoPanel.TabIndex = 5
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(130, 51)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 14)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén origen:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(130, 107)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 14)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Fecha autocarb.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFAutoabasto
        '
        Me.dtpFAutoabasto.CustomFormat = ""
        Me.dtpFAutoabasto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFAutoabasto.Location = New System.Drawing.Point(130, 135)
        Me.dtpFAutoabasto.Name = "dtpFAutoabasto"
        Me.dtpFAutoabasto.Size = New System.Drawing.Size(216, 21)
        Me.dtpFAutoabasto.TabIndex = 4
        '
        'frmMovimientoAutoCarburacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(598, 328)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.grpDatos, Me.btnCancelar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoAutoCarburacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salida de gas por autocarburacion"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Funcion que registra la medicion fisica de los almacenes "CODIGO PACO"
    Private Sub MedicionFisica(ByVal MovimientoSalida As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(2, MovimientoSalida, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.PosicionarInicio()
        End If
        'If cboCorporativo.Items.Count > 1 Then
        '    cboCorporativo.PosicionarInicio()
        'End If
        cboCamion.PosicionarInicio()
        lblLitros.Text = "0"
    End Sub

    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()
        If cboAlmacen.Text <> "" And cboCamion.Text <> "" And CType(lblLitros.Text, Decimal) > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function ValidarRangoFechaVenta() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(0, cboAlmacen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
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

    ' Carga el producto del almacén, debido a que la carga se realiza directamente del contenedor
    Private Sub ProductoContenedor()
        Cursor = Cursors.WaitCursor
        Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacen.Identificador)
        oProductoContenedor.CargaDatos()
        Producto = oProductoContenedor.Identificador
        oProductoContenedor = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Si el usuario tiene privilegios de realizar cargas de diferentes empresas, habilita el combo de las empresas 
    ' para que el usuario pueda relizar cargas de todas las empresas
    Private Sub HabilitarEmpresa()
        cboCorporativo.CargaDatos(0)
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)
        If GLOBAL_VerEmpresas = False Then
            cboCorporativo.Enabled = False
            ActiveControl = cboAlmacen
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

    ' Manda al procedimientos los valores de los parametros e imprime el ticket de trasiego
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
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Realiza los movimientos del trasiego
    Private Sub RealizarMovimientos(ByVal Almacen As Integer, ByVal Cantidad As Decimal)
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim Kilos As Decimal
            Dim Litros As Decimal
            Dim FechaMov As DateTime
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            FechaMov = dtpFMovimiento.Value
            If cboAlmacen.TipoProducto = 5 Then
                Kilos = Cantidad
                Litros = Kilos / CType(FactorDensidad, Decimal)
            Else
                Litros = Cantidad
                Kilos = Litros * CType(FactorDensidad, Decimal)
            End If
            'Kilos = Cantidad * CType(FactorDensidad, Decimal)

            Dim Ano As Integer
            Ano = dtpFMovimiento.Value.Year

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, Almacen, 0, TipoMovimiento, 0)

            Dim oMovimientoAlmacenS As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, Almacen, _
                                           FechaMov, Kilos, Litros, TipoMovimiento, dtpFAutoabasto.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            If cboAlmacen.TipoProducto <> 5 Then
                ProductoPanel.RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenS.Identificador, Litros, _
                                             Producto)
            Else
                ProductoPanel.RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenS.Identificador)
            End If
            ' Registra la información en la tabla de AutoTanqueTurno
            Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
            oAutotanqueTurno.CargaDatos(Ano, 0, dtpFAutoabasto.Value.Date, 0, 0, 1, _
                    cboCamion.Identificador, 1, 0, oMovimientoAlmacenS.Identificador, cboAlmacen.Identificador, False)
            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
            End If

            'Realiza la medicion fisica automatica del almacen "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                MedicionFisica(oMovimientoAlmacenS.Identificador)
            End If

            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacen = Nothing
            oAutotanqueTurno = Nothing
            DatosSalvados = True
            Limpiar()
            Cursor = Cursors.Default
            Close()
        End If
    End Sub

    '' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    'Private Function VerificarExistencias(ByVal Almacen As Integer, ByVal Cantidad As Decimal) As Boolean
    '    Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(1, Almacen, Producto, _
    '                                  Cantidad)
    '    VerificaExistencia.CargaDatos()
    '    If VerificaExistencia.Existencia = 0 Then
    '        Return False
    '    End If
    '    Return True
    'End Function
    ' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    Private Function VerificarExistencias(ByVal Almacen As Integer, ByVal Cantidad As Decimal) As Boolean
        If cboAlmacen.TipoProducto = 5 Then
            Return (ProductoPanel.VerificarExistencias(Almacen))
        Else
            Return (ProductoPanel.VerificarExistencias(Almacen, Cantidad, Producto))
        End If

    End Function

    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos()
        Dim Litros As Decimal
        Dim Almacen As Integer
        Litros = CType(lblLitros.Text, Decimal)
        Almacen = cboAlmacen.Identificador

        If VerificarExistencias(Almacen, Litros) Then
            RealizarMovimientos(Almacen, Litros)
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(1)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
        End If
    End Sub

    Private Sub frmMovimientoAutoabasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        HabilitarEmpresa()
        'cboCorporativo.CargaDatos(0)
        If cboCorporativo.Text <> "" Then
            cboAlmacen.CargaDatos(20, GLOBAL_Usuario, cboCorporativo.Identificador)
            ProductoContenedor()
        End If
        If cboAlmacen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
            If cboAlmacen.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
        End If
        cboCamion.CargaDatos(1, GLOBAL_Usuario)
        DatosSalvados = False
        Cursor = Cursors.Default
    End Sub

    ' Evento del control cboCorporativo en donde carga los almacenes correspondientes a la empresa seleccionada
    Private Sub cboCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativo.SelectedIndexChanged
        If cboCorporativo.Focused And cboCorporativo.Text <> "" Then
            Refresh()
            Cursor = Cursors.WaitCursor
            cboAlmacen.CargaDatos(20, GLOBAL_Usuario, cboCorporativo.Identificador)
            If cboAlmacen.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
                ProductoContenedor()
                If cboAlmacen.TipoProducto = 5 Then
                    lblProducto.Text = "Kilos:"
                Else
                    lblProducto.Text = "Litros:"
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    ' Cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnCancelar.Click
        Close()
    End Sub

    ' Habilita el botón aceptar si los controles cumplen con la condición
    Private Sub cboCamion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboCamion.SelectedIndexChanged
        HabilitarAceptar()
    End Sub

    ' Cuando seleccionamos un almacen carga la información necesaria en los controles
    Private Sub cboAlmacen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboAlmacen.SelectedIndexChanged
        If (cboAlmacen.Focused) And (cboAlmacen.Text <> "") Then
            ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
            ProductoContenedor()
            If cboAlmacen.Text <> "" Then
                If cboAlmacen.TipoProducto = 5 Then
                    lblProducto.Text = "Kilos:"
                Else
                    lblProducto.Text = "Litros:"
                End If
            End If
            HabilitarAceptar()
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        lblLitros.Text = Format(ProductoPanel.SumarKilos(), "n")
        HabilitarAceptar()
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboAlmacen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCorporativo.KeyDown, dtpFMovimiento.KeyDown, ProductoPanel.KeyDown, cboCamion.KeyDown, cboAlmacen.KeyDown, dtpFAutoabasto.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmMovimientoAutoabasto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ' 20060617CAGP$007 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                cboAlmacen.Identificador, 0) ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            ValidarMovimientos()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
        ' 20060617CAGP$007 /F
    End Sub
End Class
