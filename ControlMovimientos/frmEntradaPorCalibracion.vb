' Registra la información de las pruebas de calibracion realizada a los autotanques
' la salida de gas se registra en venta estaionaria, la entrada de gas por calibracion se debe
' de registrar en esta venta
' Autor: Claudia Aurora García Patiño
' Fecha: 13 de Noviembre de 2006

Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmEntradaPorCalibracion
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private Producto As Integer

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFTraslado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTotInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboAlmacenDestino As PortatilClasses.Combo.ComboAlmacen
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEntradaPorCalibracion))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtTotFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTotInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacenDestino = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpFTraslado = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(514, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(514, 49)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotFinal, Me.txtTotInicial, Me.Label5, Me.Label7, Me.cboCelula, Me.Label3, Me.cboCorporativo, Me.Label2, Me.cboAlmacenDestino, Me.Label13, Me.lblProducto, Me.lblKilos, Me.Label6, Me.dtpFMovimiento, Me.dtpFTraslado, Me.Label1})
        Me.grpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatos.Location = New System.Drawing.Point(10, 9)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 263)
        Me.grpDatos.TabIndex = 19
        Me.grpDatos.TabStop = False
        '
        'txtTotFinal
        '
        Me.txtTotFinal.AutoSize = False
        Me.txtTotFinal.Location = New System.Drawing.Point(132, 193)
        Me.txtTotFinal.MaxLength = 12
        Me.txtTotFinal.Name = "txtTotFinal"
        Me.txtTotFinal.Size = New System.Drawing.Size(216, 21)
        Me.txtTotFinal.TabIndex = 44
        Me.txtTotFinal.Text = ""
        '
        'txtTotInicial
        '
        Me.txtTotInicial.AutoSize = False
        Me.txtTotInicial.Location = New System.Drawing.Point(132, 165)
        Me.txtTotInicial.MaxLength = 12
        Me.txtTotInicial.Name = "txtTotInicial"
        Me.txtTotInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtTotInicial.TabIndex = 43
        Me.txtTotInicial.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(19, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Totalizador inicial:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(20, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Totalizador final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(131, 52)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Célula:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCorporativo.ItemHeight = 13
        Me.cboCorporativo.Location = New System.Drawing.Point(131, 24)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Empresa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenDestino
        '
        Me.cboAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenDestino.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacenDestino.ItemHeight = 13
        Me.cboAlmacenDestino.Location = New System.Drawing.Point(131, 80)
        Me.cboAlmacenDestino.Name = "cboAlmacenDestino"
        Me.cboAlmacenDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenDestino.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén destino:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(56, 224)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(35, 14)
        Me.lblProducto.TabIndex = 17
        Me.lblProducto.Text = "Litros:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(136, 224)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 15
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(17, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(131, 108)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 3
        Me.dtpFMovimiento.Value = New Date(2005, 2, 21, 17, 6, 50, 136)
        '
        'dtpFTraslado
        '
        Me.dtpFTraslado.CustomFormat = ""
        Me.dtpFTraslado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFTraslado.Location = New System.Drawing.Point(131, 136)
        Me.dtpFTraslado.Name = "dtpFTraslado"
        Me.dtpFTraslado.Size = New System.Drawing.Size(216, 21)
        Me.dtpFTraslado.TabIndex = 4
        Me.dtpFTraslado.Value = New Date(2005, 2, 21, 17, 6, 50, 16)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(17, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Fecha entrada:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEntradaPorCalibracion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(598, 288)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.grpDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEntradaPorCalibracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada por calibración (pruebas)"
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

    Private Sub ConsultaTotalizador()
        If GLOBAL_IncrementaTotalizador = "1" Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDestino.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 Then
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
                oAutotanqueTurno.ConsultarAutotanqueTurno(0, oAlmacenOrigen.AlmacenGas, 0, 0)
                If Trim(oAutotanqueTurno.StatusBascula) <> "ABIERTO" Then
                    txtTotInicial.Text = oAutotanqueTurno.TotalizadorFinal.ToString("N2")
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(88, cboAlmacenDestino.Text)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboAlmacenDestino.PosicionarInicio()
                    ActiveControl = cboAlmacenDestino
                End If
            End If
        Else
            OperacionTotalizador()
        End If
    End Sub

    Private Sub OperacionTotalizador()
        txtTotInicial.ReadOnly = True
        txtTotFinal.ReadOnly = False
    End Sub

    Function ValidaTotalizador() As Boolean
        If txtTotInicial.ReadOnly And txtTotFinal.ReadOnly Then
            Return True
        ElseIf txtTotFinal.ReadOnly = False Then
            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                Dim TotInicial As Decimal = CType(txtTotInicial.Text, Decimal)
                Dim TotFinal As Decimal = CType(txtTotFinal.Text, Decimal)
                If TotInicial <= TotFinal Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function


    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        lblKilos.Text = "0"
        If cboAlmacenDestino.Items.Count > 1 Then
            cboAlmacenDestino.SelectedIndex = -1
            cboAlmacenDestino.SelectedIndex = -1
        End If
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboAlmacenDestino.Text <> "" And cboCelula.Text <> "" And _
           cboCorporativo.Text <> "" And CType(lblKilos.Text, Decimal) > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Registra los productos del movimiento, dependiendo del almacén origen y destino
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal TipoMovimiento As Integer)

    End Sub

    ' Realiza los movimientos originados por el traspaso
    Public Function RealizarMovimientos() As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim Kilos As Decimal
            Dim Litros As Decimal
            Dim FechaMov As DateTime
            Dim Ano As Integer

            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            Ano = dtpFMovimiento.Value.Year

            Litros = CType(lblKilos.Text, Decimal)
            Kilos = Litros * CType(FactorDensidad, Decimal)
            FechaMov = dtpFMovimiento.Value

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacenDestino.Identificador, 0, 26, 0)

            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenDestino.Identificador, _
                                   FechaMov, Kilos, Litros, 26, dtpFTraslado.Value, oFolioMovimientoAlmacen.NDocumento, _
                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            'RegistraMovimientoProducto(cboAlmacenDestino.Identificador, oMovimientoAlmacenS.Identificador)
            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
            End If

            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                ' Registra la carga en autotanque turno
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(2)
                oAutotanqueTurno.CargaDatos(Ano, 0, dtpFTraslado.Value.Date, 0, _
                                        cboAlmacenDestino.Celula, 1, 0, 1, 0, _
                                        oMovimientoAlmacenS.Identificador, cboAlmacenDestino.Identificador, True)
            End If

            'Llama a la funcion de medicion fisica "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                MedicionFisica(oMovimientoAlmacenS.Identificador)
            End If

            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            ActiveControl = cboCorporativo
            Cursor = Cursors.Default
        End If
    End Function

    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos()
        RealizarMovimientos()
    End Sub

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacenDestino.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
            dtpFTraslado.Value = Fecha
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = FechaActual()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Carga el producto del almacén
    Private Sub ProductoContenedor()
        If cboAlmacenDestino.Text <> "" Then
            Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacenDestino.Identificador)
            oProductoContenedor.CargaDatos()
            Producto = oProductoContenedor.Identificador
            oProductoContenedor = Nothing
        End If
    End Sub

    ' Habilita los privilegios del usuario, para ver si puede realizar transpasos entre empresas
    Private Sub HabilitarEmpresa()
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)
        'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoOrigen.Identificador, GLOBAL_Usuario)
        cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        If cboCelula.Text <> "" Then
            cboAlmacenDestino.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
        End If
        If cboAlmacenDestino.Text <> "" Then
            ProductoContenedor()
        End If
        If GLOBAL_VerEmpresas = False Then
            cboCorporativo.Enabled = False
            ActiveControl = cboCelula
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
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketTraspaso.rpt")

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

    Private Sub frmEntradaPorCalibracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        cboCorporativo.CargaDatos(0)
        HabilitarEmpresa()
        ProductoContenedor()
        Cursor = Cursors.Default
    End Sub


    Private Sub cboAlmacenDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlmacenDestino.SelectedIndexChanged
        If cboAlmacenDestino.Focused And cboAlmacenDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ProductoContenedor()
            HabilitarAceptar()
            lblKilos.Text = "0.00"
            Cursor = Cursors.Default
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboCorporativoOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCelula.KeyDown, dtpFMovimiento.KeyDown, dtpFTraslado.KeyDown, cboCorporativo.KeyDown, cboAlmacenDestino.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmEntradaPorCalibracion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cboCorporativoOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCorporativo.SelectedIndexChanged
        If cboCorporativo.Focused And cboCorporativo.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
            cboAlmacenDestino.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Focused And cboCelula.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboAlmacenDestino.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
            If cboAlmacenDestino.Text <> "" Then
                ProductoContenedor()
                lblKilos.Text = "0.00"
            End If
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                cboAlmacenDestino.Identificador, 0)
        If oMovimiento.RealizarMovimiento() Then
            ValidarMovimientos()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
    End Sub
End Class
