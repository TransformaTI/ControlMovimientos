Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoInicial
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoInicial))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label3, Me.ProductoPanel, Me.cboCorporativo, Me.Label2, Me.cboAlmacen, Me.Label13, Me.lblProducto, Me.lblKilos, Me.Label6, Me.dtpFMovimiento})
        Me.grpDatos.Location = New System.Drawing.Point(10, 9)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 331)
        Me.grpDatos.TabIndex = 15
        Me.grpDatos.TabStop = False
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
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Célula:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(8, 137)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(463, 152)
        Me.ProductoPanel.TabIndex = 4
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(131, 80)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 1
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
        Me.lblProducto.Location = New System.Drawing.Point(311, 303)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(32, 13)
        Me.lblProducto.TabIndex = 17
        Me.lblProducto.Text = "Kilos:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(359, 299)
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
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(514, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(514, 49)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMovimientoInicial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(598, 352)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatos, Me.btnAceptar, Me.btnCancelar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoInicial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario inicial"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.PosicionarInicio()
        End If
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
        lblKilos.Text = "0"
    End Sub

    'Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboAlmacen.Text <> "" And cboCorporativo.Text <> "" And CType(lblKilos.Text, Decimal) > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    Private Function VerificarExistencias(ByVal Almacen As Integer) As Boolean
        Dim oVerificaExistencia As New PortatilClasses.Consulta.cExistencia(4, Almacen, 0, 0)
        oVerificaExistencia.CargaDatos()
        If oVerificaExistencia.Existencia = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Registra los productos del movimiento, dependiendo del almacén origen y destino
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
        ' Registra los productos contenidos en el panel en kilos
        If cboAlmacen.TipoProducto = 5 Then
            ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
        End If
        ' Registra el producto enviado en litros
        If cboAlmacen.TipoProducto <> 5 Then
            ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal), Producto)
        End If

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
            If cboAlmacen.TipoProducto = 5 Then
                Kilos = CType(lblKilos.Text, Decimal)
                Litros = Kilos / CType(FactorDensidad, Decimal)
            Else
                Litros = CType(lblKilos.Text, Decimal)
                Kilos = Litros * CType(FactorDensidad, Decimal)
            End If
            FechaMov = dtpFMovimiento.Value

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacen.Identificador, 0, 22, 0)

            Dim oMovimientoAlmacenE As New cMovimientoAlmacen(0, 0, cboAlmacen.Identificador, _
                                       FechaMov, Kilos, Litros, 22, FechaMov, oFolioMovimientoAlmacen.NDocumento, _
                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenE.Identificador)

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenE.Identificador)
            End If

            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            ProductoPanel.BorrarDatos()
            If cboCorporativo.Enabled Then
                ActiveControl = cboCorporativo()
            Else
                ActiveControl = cboAlmacen
            End If
            Cursor = Cursors.Default
        End If
    End Function

    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos()
        If VerificarExistencias(cboAlmacen.Identificador) Then
            If ProductoPanel.StockMinimo(cboAlmacen.Identificador, cboAlmacen.TipoProducto) Then
                RealizarMovimientos()
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(5)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = ProductoPanel.txtCantidad1
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(75)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
        End If
    End Sub

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
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
        If cboAlmacen.Text <> "" Then
            Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacen.Identificador)
            oProductoContenedor.CargaDatos()
            Producto = oProductoContenedor.Identificador
            oProductoContenedor = Nothing
        End If
    End Sub

    ' Habilita los privilegios del usuario, para ver si puede realizar transpasos entre empresas
    Private Sub HabilitarEmpresa()
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)
        'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativo.Identificador, GLOBAL_Usuario)
        cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        cboAlmacen.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
        If GLOBAL_VerEmpresas = False Then
            cboCorporativo.Enabled = False
            ActiveControl = cboCelula
        End If
        If cboAlmacen.Text <> "" Then
            ProductoContenedor()
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
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMovimientoInicial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        cboCorporativo.CargaDatos(0)
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)
        'cboAlmacen.CargaDatos(5, GLOBAL_Usuario, cboCorporativo.Identificador)
        'ProductoContenedor()
        HabilitarEmpresa()
        If cboAlmacen.Text <> "" Then
            'If cboAlmacen.TipoProducto = 5 Then
            '    ProductoPanel.CargarProducto(cboAlmacen.TipoProducto)
            'Else
            '    ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
            'End If
            ProductoPanel.CargarProducto(cboAlmacen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacen.Identificador)

            If cboAlmacen.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
        End If
        'HabilitarEmpresa()
        Cursor = Cursors.Default
    End Sub

    Private Sub cboCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativo.SelectedIndexChanged
        If cboCorporativo.Focused And cboCorporativo.Text <> "" Then
            Cursor = Cursors.WaitCursor
            'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativo.Identificador, GLOBAL_Usuario)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
            cboAlmacen.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Focused And cboCelula.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboAlmacen.CargaDatos(15, GLOBAL_Usuario, cboCelula.Identificador)
            If cboAlmacen.Text <> "" Then
                ProductoContenedor()
                ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
                If cboAlmacen.TipoProducto = 5 Then
                    lblProducto.Text = "Kilos:"
                Else
                    lblProducto.Text = "Litros:"
                End If
                lblKilos.Text = "0.00"
            End If
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.SelectedIndexChanged
        If cboAlmacen.Focused And cboAlmacen.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ProductoContenedor()
            ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
            If cboAlmacen.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
            HabilitarAceptar()
            lblKilos.Text = "0.00"
            Cursor = Cursors.Default
        End If
    End Sub

    ' Evento del control lblKilos
    Private Sub lblKilos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles lblKilos.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub cboCorporativo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboCorporativo.KeyDown, cboAlmacen.KeyDown, dtpFMovimiento.KeyDown, ProductoPanel.KeyDown, _
    cboCelula.KeyDown
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

    Private Sub frmMovimientoInicial_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ValidarMovimientos()
    End Sub
End Class
