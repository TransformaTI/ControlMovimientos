Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReposicionFugas
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cboAlmacenDestino As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents cboAlmacenOrigen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReposicionFugas))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFVenta = New System.Windows.Forms.DateTimePicker()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboAlmacenDestino = New PortatilClasses.Combo.ComboAlmacen()
        Me.cboAlmacenOrigen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(514, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(514, 82)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnConsultar, "Consulta las existencias del almacén origen")
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label3, Me.cboCorporativo, Me.ProductoPanel, Me.Label2, Me.dtpFVenta, Me.lblCamion, Me.lblRuta, Me.cboAlmacenDestino, Me.cboAlmacenOrigen, Me.Label12, Me.Label13, Me.Label10, Me.lblKilos, Me.Label6, Me.Label4, Me.Label5, Me.Label1, Me.dtpFMovimiento})
        Me.grpDatos.Location = New System.Drawing.Point(10, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 444)
        Me.grpDatos.TabIndex = 8
        Me.grpDatos.TabStop = False
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(128, 52)
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
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Location = New System.Drawing.Point(128, 24)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativo.TabIndex = 0
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(9, 252)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(463, 152)
        Me.ProductoPanel.TabIndex = 6
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Fecha reposición:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFVenta
        '
        Me.dtpFVenta.CustomFormat = ""
        Me.dtpFVenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFVenta.Location = New System.Drawing.Point(128, 224)
        Me.dtpFVenta.Name = "dtpFVenta"
        Me.dtpFVenta.Size = New System.Drawing.Size(216, 21)
        Me.dtpFVenta.TabIndex = 5
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Location = New System.Drawing.Point(128, 168)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(352, 21)
        Me.lblCamion.TabIndex = 29
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(128, 136)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenDestino
        '
        Me.cboAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenDestino.Location = New System.Drawing.Point(128, 107)
        Me.cboAlmacenDestino.Name = "cboAlmacenDestino"
        Me.cboAlmacenDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenDestino.TabIndex = 3
        '
        'cboAlmacenOrigen
        '
        Me.cboAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenOrigen.Location = New System.Drawing.Point(128, 79)
        Me.cboAlmacenOrigen.Name = "cboAlmacenOrigen"
        Me.cboAlmacenOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenOrigen.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Almacén destino:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén origen:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(311, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Kilos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(359, 414)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 15
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Camión:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(128, 196)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(514, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmReposicionFugas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(598, 464)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConsultar, Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReposicionFugas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reposición de fugas a rutas portátiles"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private Titulo As String

    'Funcion que registra la medicion fisica "CODIGO PACO"
    Private Sub MedicionFisica(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub


    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        lblKilos.Text = "0"
        lblRuta.Text = ""
        lblCamion.Text = ""
        If cboAlmacenDestino.Items.Count > 1 Then
            cboAlmacenDestino.SelectedIndex = -1
            cboAlmacenDestino.SelectedIndex = -1
        End If
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboAlmacenOrigen.Text <> "" And cboAlmacenDestino.Text <> "" And CType(lblKilos.Text, Decimal) <> 0  Then
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
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacenOrigen.Identificador, 0, 28, 0)

            'Registra el movimiento de salida
            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrigen.Identificador, dtpFMovimiento.Value, _
                                       Kilos, Litros, 28, dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            'Registra el detalle de los productos salida
            ProductoPanel.RegistraMovimientoProducto(cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador)
            'Regitra el movimiento de entrada
            Dim oMovimientoAlmacenE As New cMovimientoAlmacen(0, 0, cboAlmacenDestino.Identificador, dtpFMovimiento.Value, _
                                      Kilos, Litros, 29, dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                      oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                      oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            'Registra el detalle de los productos de entrada
            ProductoPanel.RegistraMovimientoProducto(cboAlmacenDestino.Identificador, oMovimientoAlmacenE.Identificador)
            ' Registra los almacenes que se realizo el traspaso
            Dim oMovimientoEntreAlmacenes As New cMovimientoEntreAlmacenes(0, cboAlmacenDestino.Identificador, oMovimientoAlmacenE.Identificador, _
                                                         cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador)
            oMovimientoEntreAlmacenes.CargaDatos()

            'Registro de las mediciones físicas del almacen origen y destino "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                MedicionFisica(oMovimientoAlmacenS.Identificador)
                MedicionFisica(oMovimientoAlmacenE.Identificador)
            End If

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenE.Identificador)
            End If

            oMovimientoEntreAlmacenes = Nothing
            oMovimientoAlmacenS = Nothing
            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            ProductoPanel.BorrarDatos()
            Cursor = Cursors.Default
        End If
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function ValidarRangoFechaVenta() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(0, cboAlmacenDestino.Identificador)
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
        'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativo.Identificador, GLOBAL_Usuario)
        cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        ' Carga almacenes de tipo anden por CELULA
        cboAlmacenOrigen.CargaDatos(16, GLOBAL_Usuario, cboCelula.Identificador)
        ' Carga almaceens de tipo Ruta Portatil por CELULA
        cboAlmacenDestino.CargaDatos(17, GLOBAL_Usuario, cboCelula.Identificador)
        If (cboAlmacenDestino.Items.Count = 0) Or (cboAlmacenDestino.Items.Count > 1) Then
            ProductoPanel.BorrarDatos()
        End If
        If cboAlmacenDestino.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
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
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketTraslado.rpt")

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
    Private Sub frmCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        HabilitarEmpresa()
        Titulo = "Reposición de fugas a rutas portátiles"
    End Sub

    ' Evento del boton btnCancelar, cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ' Evento de cboAlmacenDestino, muestra los productos a ser cargados
    Private Sub cboAlmacenDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboAlmacenDestino.SelectedIndexChanged
        If cboAlmacenDestino.Focused Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim cRuta As New nombreRuta(0, cboAlmacenDestino.Identificador)
            Dim cCamion As New nombreCamion(0, cboAlmacenDestino.Identificador)
            cRuta.CargaDatos()
            lblRuta.Text = cRuta.Descripcion
            lblRuta.Tag = cRuta.Identificador
            cCamion.CargaDatos()
            lblCamion.Text = cCamion.Descripcion
            lblCamion.Tag = cCamion.Identificador

            HabilitarAceptar()
            If cboAlmacenDestino.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
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
            If ProductoPanel.StockMinimo(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto) Then
                RealizarMovimientos()
                ActiveControl = cboAlmacenOrigen
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(5)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = ProductoPanel.txtCantidad1
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(1)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
        End If
    End Sub

    ' Evento del botón cboAlmacenOrigen, llama a la que habilitará el boton de Aceptar
    Private Sub cboAlmacenOrigen_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles lblKilos.TextChanged, cboAlmacenOrigen.SelectedIndexChanged, _
    cboAlmacenDestino.SelectedIndexChanged
        HabilitarAceptar()
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboAlmacenOrigen.KeyDown, cboAlmacenDestino.KeyDown, dtpFMovimiento.KeyDown, dtpFVenta.KeyDown, _
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
            ' Carga almaceens de tipo Ruta Portatil por CELULA
            cboAlmacenDestino.CargaDatos(17, GLOBAL_Usuario, cboCelula.Identificador)

            If (cboAlmacenDestino.Items.Count = 0) Or (cboAlmacenDestino.Items.Count > 1) Then
                ProductoPanel.BorrarDatos()
            End If
            If cboAlmacenDestino.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
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
            ' Carga almaceens de tipo Ruta Portatil por CELULA
            cboAlmacenDestino.CargaDatos(17, GLOBAL_Usuario, cboCelula.Identificador)
            If (cboAlmacenDestino.Items.Count = 0) Or (cboAlmacenDestino.Items.Count > 1) Then
                ProductoPanel.BorrarDatos()
            End If
            If cboAlmacenDestino.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
                ValidarRangoFechaVenta()

                Dim cRuta As New nombreRuta(0, cboAlmacenDestino.Identificador)
                Dim cCamion As New nombreCamion(0, cboAlmacenDestino.Identificador)
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
