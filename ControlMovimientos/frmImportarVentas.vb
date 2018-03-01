Public Class frmImportarVentas
    Inherits System.Windows.Forms.Form

    Private oImportar As ExportarAExcel.ImportarVentas

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
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCarburacion As System.Windows.Forms.Label
    Friend WithEvents lblEstacionario As System.Windows.Forms.Label
    Friend WithEvents lblPortatil As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblObsequio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmImportarVentas))
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCarburacion = New System.Windows.Forms.Label()
        Me.lblEstacionario = New System.Windows.Forms.Label()
        Me.lblPortatil = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblObsequio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Bitmap)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(144, 150)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.TabIndex = 0
        Me.btnImportar.Text = "Cargar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Pórtatil:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Estacionario:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Carburación:"
        '
        'lblCarburacion
        '
        Me.lblCarburacion.Location = New System.Drawing.Point(118, 84)
        Me.lblCarburacion.Name = "lblCarburacion"
        Me.lblCarburacion.Size = New System.Drawing.Size(89, 16)
        Me.lblCarburacion.TabIndex = 8
        Me.lblCarburacion.Text = "Carburación:"
        Me.lblCarburacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstacionario
        '
        Me.lblEstacionario.Location = New System.Drawing.Point(118, 63)
        Me.lblEstacionario.Name = "lblEstacionario"
        Me.lblEstacionario.Size = New System.Drawing.Size(89, 16)
        Me.lblEstacionario.TabIndex = 7
        Me.lblEstacionario.Text = "Estacionario:"
        Me.lblEstacionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPortatil
        '
        Me.lblPortatil.Location = New System.Drawing.Point(118, 42)
        Me.lblPortatil.Name = "lblPortatil"
        Me.lblPortatil.Size = New System.Drawing.Size(89, 16)
        Me.lblPortatil.TabIndex = 6
        Me.lblPortatil.Text = "Pórtatil:"
        Me.lblPortatil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(80, 21)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(191, 16)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(286, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(286, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblObsequio
        '
        Me.lblObsequio.Location = New System.Drawing.Point(117, 105)
        Me.lblObsequio.Name = "lblObsequio"
        Me.lblObsequio.Size = New System.Drawing.Size(89, 16)
        Me.lblObsequio.TabIndex = 42
        Me.lblObsequio.Text = "Carburación:"
        Me.lblObsequio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Obsequios:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(219, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 16)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Kgs."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(219, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 16)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Kgs."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(219, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Lts."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(219, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Lts."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmImportarVentas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(378, 192)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.Label9, Me.Label8, Me.Label6, Me.lblObsequio, Me.Label7, Me.btnCancelar, Me.btnAceptar, Me.lblCarburacion, Me.lblEstacionario, Me.lblPortatil, Me.lblFecha, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.btnImportar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmImportarVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar ventas"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Limpiar()
        lblFecha.Text = ""
        lblPortatil.Text = ""
        lblEstacionario.Text = ""
        lblCarburacion.Text = ""
        btnAceptar.Enabled = False
    End Sub

    Private Sub HabilitarAcpetar()
        If lblFecha.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub RegistrarInformacion()
        If oImportar.Lista.Count > 0 Then
            Dim i As Integer
            While i < oImportar.Lista.Count
                Dim oDatos As ExportarAExcel.ListaAlmacen
                oDatos = CType(oImportar.Lista.Item(i), ExportarAExcel.ListaAlmacen)

                Dim oAlmacen As New PortatilClasses.Consulta.cMovimientoAlmacenImportar()
                oAlmacen.Consulta(1, oDatos.AlmacenGas, oImportar._Fecha.Date, oDatos.TipoMovimiento)

                If oAlmacen.Identificador = 0 Then
                    If oDatos.Kilos > 0 Then
                        oAlmacen.Actualizar(0, oDatos.AlmacenGas, oImportar._Fecha.Date, oDatos.Kilos, oDatos.Litros, oDatos.TipoMovimiento, oImportar._Fecha.Date, GLOBAL_Usuario, oDatos.Rm)
                    End If

                Else
                    If oDatos.Kilos > 0 Then
                        Dim Result As DialogResult
                        Result = MessageBox.Show("La venta de esa ruta " & oAlmacen.DesAlmacen & " ya existe, ¿desea cargarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Result = DialogResult.Yes Then
                            oAlmacen.Actualizar(0, oDatos.AlmacenGas, oImportar._Fecha.Date, oDatos.Kilos, oDatos.Litros, oDatos.TipoMovimiento, oImportar._Fecha.Date, GLOBAL_Usuario, oDatos.Rm)
                        End If
                    End If
                End If
                i = i + 1
            End While
            MessageBox.Show("Ventas registradas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub frmImportarVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        oImportar = New ExportarAExcel.ImportarVentas(GLOBAL_Usuario, GLOBAL_Password, GLOBAL_ConString)
        oImportar.LeerArchivo()
        lblPortatil.Text = Format(oImportar._Portatil, "n")
        lblEstacionario.Text = Format(oImportar._Estacionario, "n")
        lblCarburacion.Text = Format(oImportar._Carburacion, "n")
        lblObsequio.Text = Format(oImportar._Obsequios, "n")
        lblFecha.Text = oImportar._Fecha.ToLongDateString

        HabilitarAcpetar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(14)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            RegistrarInformacion()
            btnAceptar.Enabled = False
        End If
    End Sub
End Class
