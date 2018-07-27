'Autor: Claudia Aurora García Patiño
'Fecha: 02 de Marzo del 2006
'Descripcion: Regitras las entradas por devolucion de gas por parte del cliente

'CAGP20060516
'Pantalla que se quito el acceso, analizaron bien el movimiento y no fue aprobado

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoDevolucionEntrada
    Inherits System.Windows.Forms.Form

    Private Producto As Integer
    Private CelulaCliente As Integer
    Private FactorDensidad As String
    Private DatosSalvados As Boolean
    Private NumEnter As Short

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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCamion As PortatilClasses.Combo.ComboCamion
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents dtpFResguardo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoDevolucionEntrada))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCamion = New PortatilClasses.Combo.ComboCamion()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFResguardo = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboCamion, Me.cboCorporativo, Me.Label2, Me.Label10, Me.lblLitros, Me.ProductoPanel, Me.txtCliente, Me.lblRuta, Me.cboAlmacen, Me.Label12, Me.Label13, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblCliente, Me.Label3, Me.Label7, Me.dtpFResguardo})
        Me.grpDatos.Location = New System.Drawing.Point(12, 14)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 458)
        Me.grpDatos.TabIndex = 10
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(308, 432)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 14)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Litros:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLitros
        '
        Me.lblLitros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLitros.Location = New System.Drawing.Point(358, 427)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.Size = New System.Drawing.Size(120, 21)
        Me.lblLitros.TabIndex = 48
        Me.lblLitros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(7, 278)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(472, 138)
        Me.ProductoPanel.TabIndex = 6
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'txtCliente
        '
        Me.txtCliente.AutoSize = False
        Me.txtCliente.Location = New System.Drawing.Point(130, 106)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 21)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Ingrese el número de cliente")
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(130, 162)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(130, 51)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 14)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 14)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén destino:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(130, 190)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 4
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(130, 221)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 4
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(130, 134)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 32
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 14)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Fecha resguardo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFResguardo
        '
        Me.dtpFResguardo.CustomFormat = ""
        Me.dtpFResguardo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFResguardo.Location = New System.Drawing.Point(130, 249)
        Me.dtpFResguardo.Name = "dtpFResguardo"
        Me.dtpFResguardo.Size = New System.Drawing.Size(216, 21)
        Me.dtpFResguardo.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(514, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 63
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(418, 121)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 64
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(514, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 62
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMovimientoDevolucionEntrada
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 480)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnBuscar, Me.btnAceptar, Me.grpDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoDevolucionEntrada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada de gas por devolución"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    'Crea la forma de Captura de medicon estacionario "CODIGO PACO"
    Dim frmCapturaMedicionEstacionario As New MedicionFisica.frmMedicionInicialFinalEst()
    Dim frmCapturaMedicionTanque As New MedicionFisica.frmMedicionTanqueAlmacen()

    'Funcion para validar que se haga la medicion fisica "CODIGO PACO"
    Private Sub MedicionFisicaPortatil(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    'Funcion que destruye la forma de Captura de medicion fisica "CODIGO PACO"
    Private Sub DestruyeMedicionFisicaEstacionario()
        frmCapturaMedicionEstacionario = Nothing
        frmCapturaMedicionEstacionario = New MedicionFisica.frmMedicionInicialFinalEst()
        frmCapturaMedicionTanque = Nothing
        frmCapturaMedicionTanque = New MedicionFisica.frmMedicionTanqueAlmacen()
    End Sub

    'Funcion de Medicion Fisica para verificar que se haga "CODIGO PACO"
    Function MedicionFisica() As Boolean
        Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
        oAlmacenDestino.CargarAlmacenGas()

        If oAlmacenDestino.TipoAlmacengas = 4 Then
            Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacen.Identificador, 0)
            oTanque.VerificarCapacidad()
            frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacen.Text + "]"
            frmCapturaMedicionEstacionario.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$003
            If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                Return True
            Else
                DestruyeMedicionFisicaEstacionario()
                Return False
            End If
        ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
            Return True
        ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
            Return True
        ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
            Return True
        Else
            Return False
        End If

    End Function

    'Funcion de almacenar la medicion fisica "CODIGO PACO"
    Private Sub AlmacenarMedicionFisica(ByVal MovEntrada As Integer, ByVal AlmDestino As Integer)
        Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
        oAlmacenDestino.CargarAlmacenGas()
        If oAlmacenDestino.TipoAlmacengas = 4 Then
            frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, "MOVIMIENTO")
            DestruyeMedicionFisicaEstacionario()
        ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
            'frmCapturaMedicionTanque.AlmacenarInformacion(MovEntrada, AlmDestino, "MOVIMIENTO")
            'DestruyeMedicionFisicaEstacionario()
            MedicionFisicaPortatil(MovEntrada)
        ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
            MedicionFisicaPortatil(MovEntrada)
        ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
            MedicionFisicaPortatil(MovEntrada)
        End If
    End Sub

    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblRuta.Text = ""
        lblEmpresa.Text = ""
        txtCliente.Clear()
        lblCliente.Text = ""
        lblLitros.Text = "0"
    End Sub

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        LimpiarCliente()
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.PosicionarInicio()
        End If
        'If cboCorporativo.Items.Count > 1 Then
        '    cboCorporativo.PosicionarInicio()
        'End If

        cboCamion.PosicionarInicio()
    End Sub

    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()
        If cboAlmacen.Text <> "" And txtCliente.Text <> "" And CType(lblLitros.Text, Decimal) > 0 Then
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

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Cursor = Cursors.WaitCursor
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer), 0)
        oCliente.CargaDatos()

        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo
            CelulaCliente = oCliente.Celula
        Else
            LimpiarCliente()
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, "Modulo  de carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
            txtCliente.Clear()
        End If
        oCliente = Nothing
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
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketResguardo.rpt")

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
    Private Sub RealizarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim Litros As Decimal
            Dim Kilos As Decimal
            Dim FechaMov As DateTime
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            FechaMov = dtpFMovimiento.Value

            If cboAlmacen.TipoProducto = 5 Then
                Kilos = CType(lblLitros.Text, Decimal)
                Litros = Kilos / CType(FactorDensidad, Decimal)
            Else
                Litros = CType(lblLitros.Text, Decimal)
                Kilos = Litros * CType(FactorDensidad, Decimal)
            End If

            Dim Ano As Integer
            Ano = dtpFMovimiento.Value.Year

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacen.Identificador, 0, 30, 0)

            Dim oMovimientoAlmacenE As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, cboAlmacen.Identificador, _
                                           FechaMov, Kilos, Litros, 30, dtpFResguardo.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            If cboAlmacen.TipoProducto = 5 Then
                ProductoPanel.RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenE.Identificador)
            Else
                ProductoPanel.RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenE.Identificador, Litros, _
                                                         Producto)
            End If
            ' Registra la información en la tabla de AutoTanqueTurno
            Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
            oAutotanqueTurno.CargaDatos(Ano, CType(lblRuta.Tag, Integer), dtpFResguardo.Value.Date, 0, CelulaCliente, 1, _
                    cboCamion.Identificador, 1, 0, oMovimientoAlmacenE.Identificador, cboAlmacen.Identificador, False)

            'Registra en la tabla de pedido
            Dim oPedido As New PortatilClasses.cLiquidacion(0, CType(CelulaCliente, Short), 0, 0)
            oPedido.LiquidacionPedidoyCobroPedido(Producto, dtpFMovimiento.Value, _
                    0, 0, 0, 0, 0, "ACTIVO", CType(txtCliente.Text, Integer), Now, 0, "", 1, 1, _
                    CType(lblRuta.Tag, Short), 0, 0, GLOBAL_Usuario, CType(lblRuta.Tag, Short), 1, _
                    CType(oAutotanqueTurno.AnoAtt, Short), oAutotanqueTurno.FolioMov, "PENDIENTE", 0, Now, Now, 0, _
                    oMovimientoAlmacenE.Identificador, cboAlmacen.Identificador, 0, -1, 0, 1, Kilos)

            'Llama a la funcion para almacenar la medicion fisica "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                AlmacenarMedicionFisica(oMovimientoAlmacenE.Identificador, cboAlmacen.Identificador)
            End If

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenE.Identificador)
            End If

            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing
            oAutotanqueTurno = Nothing
            oPedido = Nothing
            DatosSalvados = True
            Limpiar()
            Cursor = Cursors.Default
            Close()
        End If
    End Sub

    ' Verifica la información para poder registrar el trasiego
    Private Sub ValidarMovimientos()
        'If StockMinimo(cboAlmacen.Identificador, CType(lblLitros.Text, Decimal)) Then
        If GLOBAL_MedicionFisica Then
            If MedicionFisica() Then
                RealizarMovimientos()
            End If
        Else
            RealizarMovimientos()
        End If
        'Else
        'Dim Mensajes As New PortatilClasses.Mensaje(5)
        'MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    ' Inicializa los controles de la forma
    Private Sub frmMovimientoDevolucionEntrada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativo
        ValidarRangoFechas()
        Limpiar()
        HabilitarEmpresa()
        'cboCorporativo.CargaDatos(0)
        If cboCorporativo.Text <> "" Then
            'cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativo.Identificador)
            cboAlmacen.CargaDatos(7, GLOBAL_Usuario, cboCorporativo.Identificador)
            ProductoContenedor()
        End If
        If cboAlmacen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
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
            'cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativo.Identificador)
            cboAlmacen.CargaDatos(7, GLOBAL_Usuario, cboCorporativo.Identificador)
            If cboAlmacen.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacen.Identificador, cboAlmacen.TipoProducto)
                ProductoPanel.CargarExistencias(cboAlmacen.Identificador)
                ProductoContenedor()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    ' Cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
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
    Private Sub cboAlmacen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCorporativo.KeyDown, dtpFMovimiento.KeyDown, ProductoPanel.KeyDown, cboCamion.KeyDown, cboAlmacen.KeyDown, dtpFResguardo.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtCliente.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Valida y registra la información del trasiego
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ValidarMovimientos()
    End Sub

    ' Valida el cierre de la forma
    Private Sub frmMovimientoTrasiego_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                BuscarCliente()
                ActiveControl = dtpFMovimiento
            Else
                ActiveControl = txtCliente
            End If
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCliente.TextChanged
        HabilitarAceptar()
        NumEnter = 1
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        If NumEnter = 1 And txtCliente.Text <> "" Then
            BuscarCliente()
            NumEnter = 2
        End If
    End Sub
End Class
