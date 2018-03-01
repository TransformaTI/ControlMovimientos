Public Class frmFolioBascula
    Inherits System.Windows.Forms.Form

    Public Año As Short
    Public Folio As Integer
    Public ExisteFolio As Boolean
    Public Autotanque As Integer

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtAño As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtFolio As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cheFolio As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFolioBascula))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cheFolio = New System.Windows.Forms.CheckBox()
        Me.txtAño = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtFolio = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año del folio:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folio"
        '
        'cheFolio
        '
        Me.cheFolio.Location = New System.Drawing.Point(92, 80)
        Me.cheFolio.Name = "cheFolio"
        Me.cheFolio.TabIndex = 3
        Me.cheFolio.Text = "No hay folio"
        '
        'txtAño
        '
        Me.txtAño.AutoSize = False
        Me.txtAño.Location = New System.Drawing.Point(92, 16)
        Me.txtAño.MaxLength = 4
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(107, 21)
        Me.txtAño.TabIndex = 0
        Me.txtAño.Text = "TxtNumeroEntero3"
        '
        'txtFolio
        '
        Me.txtFolio.AutoSize = False
        Me.txtFolio.Location = New System.Drawing.Point(92, 44)
        Me.txtFolio.MaxLength = 6
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(107, 21)
        Me.txtFolio.TabIndex = 1
        Me.txtFolio.Text = "TxtNumeroEntero3"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(244, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(244, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmFolioBascula
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(346, 128)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.txtFolio, Me.txtAño, Me.cheFolio, Me.Label2, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFolioBascula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folio de pesado"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub HabilitarAceptar()
        If cheFolio.Checked Or (txtFolio.Text <> "" And txtAño.Text <> "") Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub fromFolioBascula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExisteFolio = True
        txtAño.Text = CType(Año, String)
        txtFolio.Text = ""
        Folio = 0
        ActiveControl = txtFolio
        cheFolio.Checked = False
        btnAceptar.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ExisteFolio = True
        Folio = 0
        Año = 0
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cheFolio.Checked = False Then
            Folio = CType(txtFolio.Text, Integer)
            Año = CType(txtAño.Text, Short)

            Dim oConsultaFolio As New PortatilClasses.Consulta.cAutoTanqueTurno(1)
            oConsultaFolio.ConsultarAutotanqueTurno(0, 0, Folio, Año)
            If oConsultaFolio.MovimientoAlmacen = 0 Then
                ExisteFolio = True
                Close()
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(130)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtFolio

            End If
        Else
            ExisteFolio = False
        End If
    End Sub

    Private Sub txtFolio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFolio.TextChanged, txtAño.TextChanged, cheFolio.CheckedChanged
        HabilitarAceptar()
    End Sub
End Class
