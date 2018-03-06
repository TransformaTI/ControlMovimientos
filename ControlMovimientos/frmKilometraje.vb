Public Class frmKilometraje
    Inherits System.Windows.Forms.Form

    Public Resultado As Boolean = False
    Public Celula As Integer
    Public Ruta As Integer
    Private Configuracion As Integer

    Private NumEnter As Boolean

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
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtKmFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtCamion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtNota As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtKmInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblKilometraje As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmKilometraje))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblKilometraje = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtKmFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCamion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNota = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtKmInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(491, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(491, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipo, Me.Label5, Me.lblKilometraje, Me.dtpFecha, Me.txtKmFinal, Me.txtCamion, Me.txtNota, Me.lblCliente, Me.txtKmInicial, Me.Label4, Me.Label3, Me.Label2, Me.Label12, Me.lblCamion, Me.Label6, Me.Label1})
        Me.grpDatos.Location = New System.Drawing.Point(11, 13)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(461, 267)
        Me.grpDatos.TabIndex = 15
        Me.grpDatos.TabStop = False
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Items.AddRange(New Object() {"Carburación empresa", "Carburación clientes"})
        Me.cboTipo.Location = New System.Drawing.Point(131, 25)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(216, 21)
        Me.cboTipo.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Tipo carburación:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilometraje
        '
        Me.lblKilometraje.AutoSize = True
        Me.lblKilometraje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilometraje.Location = New System.Drawing.Point(131, 226)
        Me.lblKilometraje.Name = "lblKilometraje"
        Me.lblKilometraje.Size = New System.Drawing.Size(72, 14)
        Me.lblKilometraje.TabIndex = 46
        Me.lblKilometraje.Text = "lblKilometraje"
        Me.lblKilometraje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(131, 53)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(216, 21)
        Me.dtpFecha.TabIndex = 0
        '
        'txtKmFinal
        '
        Me.txtKmFinal.AutoSize = False
        Me.txtKmFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKmFinal.Location = New System.Drawing.Point(131, 195)
        Me.txtKmFinal.MaxLength = 12
        Me.txtKmFinal.Name = "txtKmFinal"
        Me.txtKmFinal.Size = New System.Drawing.Size(216, 21)
        Me.txtKmFinal.TabIndex = 4
        Me.txtKmFinal.Text = ""
        '
        'txtCamion
        '
        Me.txtCamion.AutoSize = False
        Me.txtCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCamion.Location = New System.Drawing.Point(131, 109)
        Me.txtCamion.MaxLength = 12
        Me.txtCamion.Name = "txtCamion"
        Me.txtCamion.Size = New System.Drawing.Size(216, 21)
        Me.txtCamion.TabIndex = 2
        Me.txtCamion.Text = ""
        '
        'txtNota
        '
        Me.txtNota.AutoSize = False
        Me.txtNota.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(131, 81)
        Me.txtNota.MaxLength = 12
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(216, 21)
        Me.txtNota.TabIndex = 1
        Me.txtNota.Text = ""
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCliente.Location = New System.Drawing.Point(131, 140)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(56, 13)
        Me.lblCliente.TabIndex = 41
        Me.lblCliente.Text = "lblCliente"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtKmInicial
        '
        Me.txtKmInicial.AutoSize = False
        Me.txtKmInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKmInicial.Location = New System.Drawing.Point(131, 167)
        Me.txtKmInicial.MaxLength = 12
        Me.txtKmInicial.Name = "txtKmInicial"
        Me.txtKmInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtKmInicial.TabIndex = 3
        Me.txtKmInicial.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Cliente:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Folio nota:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Fecha carburacíon:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Kilometraje inicial:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCamion
        '
        Me.lblCamion.AutoSize = True
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCamion.Location = New System.Drawing.Point(16, 112)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(55, 13)
        Me.lblCamion.TabIndex = 23
        Me.lblCamion.Text = "Vehiculo:"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Kilometraje final:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(17, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Kilometraje:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmKilometraje
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(578, 296)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.grpDatos, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmKilometraje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar kilometraje"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Limpiar()
        txtNota.Clear()
        txtCamion.Clear()
        lblCliente.Text = ""
        txtKmInicial.Clear()
        txtKmFinal.Clear()
        lblKilometraje.Text = "0"
        cboTipo.SelectedIndex = 0
    End Sub

    Private Sub HabilitarAceptar()
        If lblCliente.Text <> "" And txtKmFinal.Text <> "" And txtKmInicial.Text <> "" And txtNota.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub ConsultaCamion()
        Dim Opcion As Integer
        If Configuracion = 0 Then
            Opcion = 2
        Else
            Opcion = 3
        End If
        Dim oCamion As New PortatilClasses.Consulta.cCamionKilometraje(Opcion)

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim strURLGateway As String = CType(oConfig.Parametros("URLGateway"), String).Trim

        If strURLGateway = "" Then
            oCamion.CargarDatos(CType(txtCamion.Text, Integer))
        Else
            oCamion.CargarDatos(CType(txtCamion.Text, Integer), strURLGateway)
        End If

        If oCamion.Identificador = 0 Then
            ActiveControl = txtCamion
            Dim Mensajes As New PortatilClasses.Mensaje(97, txtCamion.Text)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCamion.Clear()
        Else
            txtCamion.Tag = oCamion.Identificador
            lblCliente.Text = oCamion.Descripcion
            Celula = oCamion.Celula
            Ruta = oCamion.Ruta
            If oCamion.Kilometraje = 0 Then
                txtKmInicial.ReadOnly = False
                txtKmInicial.TabStop = True
            Else
                txtKmInicial.ReadOnly = True
                txtKmInicial.Text = CType(oCamion.Kilometraje, String)
                txtKmInicial.TabStop = False
                ActiveControl = txtKmFinal
                lblCliente.Text = oCamion.Descripcion
            End If
        End If
    End Sub

    Private Sub RegistrarKilometraje()
        'Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(3)
        'oAutotanqueTurno.CargaDatos(dtpFecha.Value.Year, Ruta, dtpFecha.Value, 0, Celula, 0, CType(txtCamion.Tag, Integer), 0, 0, 0, 0, False, CType(txtKmInicial.Text, Integer), CType(txtKmFinal.Text, Integer), CType(lblKilometraje.Text, Integer), CType(txtNota.Text, Integer), "")
        Dim oNotaCarburacion As New PortatilClasses.Consulta.cNotaCarburacion(0)
        oNotaCarburacion.Registrar(CType(txtNota.Text, Integer), CType(txtCamion.Tag, Integer), CType(txtKmInicial.Text, Integer), CType(txtKmFinal.Text, Integer), CType(lblKilometraje.Text, Integer), dtpFecha.Value.Date)
        Limpiar()
    End Sub

    Private Sub txtNota_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNota.KeyDown, txtCamion.KeyDown, txtKmFinal.KeyDown, txtKmInicial.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtCamion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCamion.TextChanged
        If txtCamion.Text = "" Then
            NumEnter = False
        Else
            NumEnter = True
        End If
        HabilitarAceptar()
    End Sub

    Private Sub txtCamion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCamion.Enter
        NumEnter = False
    End Sub

    Private Sub txtCamion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCamion.Leave
        If txtCamion.Text <> "" And NumEnter Then
            ConsultaCamion()
        End If
    End Sub

    Private Sub txtNota_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNota.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub frmKilometraje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
        ActiveControl = dtpFecha
    End Sub

    Private Sub txtKmFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKmFinal.Leave, txtKmInicial.Leave
        If txtKmInicial.Text <> "" And txtKmFinal.Text <> "" Then
            If CType(txtKmInicial.Text, Decimal) > CType(txtKmFinal.Text, Decimal) Then
                Dim Mensajes As New PortatilClasses.Mensaje(9)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = CType(sender, Control)
                CType(sender, Control).Select()
            End If
        End If
    End Sub

    Private Sub txtKmInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKmInicial.TextChanged, txtKmFinal.TextChanged
        Dim KmInicial As Integer = 0
        Dim KmFinal As Integer = 0
        If txtKmInicial.Text <> "" Then
            KmInicial = CType(txtKmInicial.Text, Integer)
        End If
        If txtKmFinal.Text <> "" Then
            KmFinal = CType(txtKmFinal.Text, Integer)
        End If
        lblKilometraje.Text = CType((KmFinal - KmInicial), String)
        HabilitarAceptar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            RegistrarKilometraje()
            Resultado = True
            ActiveControl = dtpFecha
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        Configuracion = cboTipo.SelectedIndex
        If cboTipo.SelectedIndex = 1 Then
            lblCamion.Text = "Número de cliente:"
            lblCliente.Text = ""
        Else
            lblCamion.Text = "Vehiculo:"
            lblCliente.Text = ""
        End If
    End Sub
End Class
