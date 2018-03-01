' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$005

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Public Class frmDucto
    Inherits System.Windows.Forms.Form

    Private Producto As Integer
    Public Operacion As String
    Private FactorDensidad As String
    Private DatosSalvados As Boolean
    Private NumEnter As Short
    Public Ducto As Integer


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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpHFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboCorporativoDestino As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpFFactura As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtIva As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtImporte As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtKilos As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtLitros As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtBarriles As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtDensidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDensidadPLC As SigaMetClasses.Controles.txtNumeroDecimal
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDucto))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtDensidadPLC = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDensidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtBarriles = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtLitros = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtKilos = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtImporte = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtIva = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpHFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpHInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtpFFactura = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.cboCorporativoDestino = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(520, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(520, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDensidadPLC, Me.Label3, Me.txtDensidad, Me.txtBarriles, Me.txtLitros, Me.txtKilos, Me.txtImporte, Me.txtIva, Me.Label8, Me.Label7, Me.Label6, Me.Label2, Me.dtpHFinal, Me.dtpHInicio, Me.Label5, Me.Label4, Me.Label43, Me.Label1, Me.dtpFMovimiento, Me.Label44, Me.dtpFFactura, Me.Label18, Me.Label19, Me.txtFactura, Me.cboCorporativoDestino, Me.Label20, Me.cboAlmacen, Me.Label22})
        Me.grpDatos.Location = New System.Drawing.Point(16, 8)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 428)
        Me.grpDatos.TabIndex = 129
        Me.grpDatos.TabStop = False
        '
        'txtDensidadPLC
        '
        Me.txtDensidadPLC.AutoSize = False
        Me.txtDensidadPLC.Location = New System.Drawing.Point(160, 360)
        Me.txtDensidadPLC.MaxLength = 10
        Me.txtDensidadPLC.Name = "txtDensidadPLC"
        Me.txtDensidadPLC.Size = New System.Drawing.Size(216, 21)
        Me.txtDensidadPLC.TabIndex = 12
        Me.txtDensidadPLC.Text = "txtDensidadPLC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 364)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "Densidad Promedio PLC:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDensidad
        '
        Me.txtDensidad.AutoSize = False
        Me.txtDensidad.Location = New System.Drawing.Point(160, 276)
        Me.txtDensidad.MaxLength = 10
        Me.txtDensidad.Name = "txtDensidad"
        Me.txtDensidad.Size = New System.Drawing.Size(216, 21)
        Me.txtDensidad.TabIndex = 9
        Me.txtDensidad.Text = "TxtNumeroDecimal3"
        '
        'txtBarriles
        '
        Me.txtBarriles.AutoSize = False
        Me.txtBarriles.Location = New System.Drawing.Point(160, 388)
        Me.txtBarriles.MaxLength = 10
        Me.txtBarriles.Name = "txtBarriles"
        Me.txtBarriles.Size = New System.Drawing.Size(216, 21)
        Me.txtBarriles.TabIndex = 13
        Me.txtBarriles.Text = "TxtNumeroDecimal3"
        '
        'txtLitros
        '
        Me.txtLitros.AutoSize = False
        Me.txtLitros.Location = New System.Drawing.Point(160, 332)
        Me.txtLitros.MaxLength = 10
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.Size = New System.Drawing.Size(216, 21)
        Me.txtLitros.TabIndex = 11
        Me.txtLitros.Text = "TxtNumeroDecimal3"
        '
        'txtKilos
        '
        Me.txtKilos.AutoSize = False
        Me.txtKilos.Location = New System.Drawing.Point(160, 304)
        Me.txtKilos.MaxLength = 10
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(216, 21)
        Me.txtKilos.TabIndex = 10
        Me.txtKilos.Text = "TxtNumeroDecimal3"
        '
        'txtImporte
        '
        Me.txtImporte.AutoSize = False
        Me.txtImporte.Location = New System.Drawing.Point(160, 248)
        Me.txtImporte.MaxLength = 10
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(216, 21)
        Me.txtImporte.TabIndex = 8
        Me.txtImporte.Text = "TxtNumeroDecimal3"
        '
        'txtIva
        '
        Me.txtIva.AutoSize = False
        Me.txtIva.Location = New System.Drawing.Point(160, 220)
        Me.txtIva.MaxLength = 10
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(216, 21)
        Me.txtIva.TabIndex = 7
        Me.txtIva.Text = "TxtNumeroDecimal3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(16, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Densidad Pemex:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(16, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 152
        Me.Label7.Text = "Barriles:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Iva:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Litros Pemex:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpHFinal
        '
        Me.dtpHFinal.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHFinal.Location = New System.Drawing.Point(160, 136)
        Me.dtpHFinal.Name = "dtpHFinal"
        Me.dtpHFinal.Size = New System.Drawing.Size(216, 21)
        Me.dtpHFinal.TabIndex = 4
        Me.dtpHFinal.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'dtpHInicio
        '
        Me.dtpHInicio.AllowDrop = True
        Me.dtpHInicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHInicio.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHInicio.Location = New System.Drawing.Point(160, 108)
        Me.dtpHInicio.Name = "dtpHInicio"
        Me.dtpHInicio.Size = New System.Drawing.Size(216, 21)
        Me.dtpHInicio.TabIndex = 3
        Me.dtpHInicio.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Hora final carga:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Hora inicio carga:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(16, 308)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(75, 13)
        Me.Label43.TabIndex = 142
        Me.Label43.Text = "Kilos Pemex:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Importe:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(160, 80)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 2
        Me.dtpFMovimiento.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(16, 84)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(109, 13)
        Me.Label44.TabIndex = 138
        Me.Label44.Text = "Fecha movimiento:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFFactura
        '
        Me.dtpFFactura.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFactura.Location = New System.Drawing.Point(160, 192)
        Me.dtpFFactura.Name = "dtpFFactura"
        Me.dtpFFactura.Size = New System.Drawing.Size(216, 21)
        Me.dtpFFactura.TabIndex = 6
        Me.dtpFFactura.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(16, 196)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 137
        Me.Label18.Text = "Fecha factura:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(16, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 136
        Me.Label19.Text = "Factura:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFactura
        '
        Me.txtFactura.AutoSize = False
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Location = New System.Drawing.Point(160, 164)
        Me.txtFactura.MaxLength = 10
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(216, 21)
        Me.txtFactura.TabIndex = 5
        Me.txtFactura.Text = "TEXTBOX8"
        '
        'cboCorporativoDestino
        '
        Me.cboCorporativoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoDestino.ItemHeight = 13
        Me.cboCorporativoDestino.Location = New System.Drawing.Point(160, 24)
        Me.cboCorporativoDestino.Name = "cboCorporativoDestino"
        Me.cboCorporativoDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoDestino.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(16, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 13)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "Empresa destino :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.ItemHeight = 13
        Me.cboAlmacen.Location = New System.Drawing.Point(160, 52)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(16, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 13)
        Me.Label22.TabIndex = 134
        Me.Label22.Text = "Almacén de gas:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDucto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 450)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDucto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ducto"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Crea la pantalla de medicion fisica "CODIGO PACO"
    Dim frmCapturaMedicion As New MedicionFisica.frmMedicionTanqueAlmacen()

    'Funcion que llama a la pantalla de medicion fisica "CODIGO PACO"
    Function MedicionFisica() As Boolean
        frmCapturaMedicion.InicializaForma(0, cboAlmacen.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, True, dtpFMovimiento.Value)
        frmCapturaMedicion.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacen.Text + "]"
        If frmCapturaMedicion.ShowDialog = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Limpiar()
        If cboCorporativoDestino.Items.Count > 1 Then
            cboCorporativoDestino.SelectedIndex = -1
            cboCorporativoDestino.SelectedIndex = -1
        End If
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.SelectedIndex = -1
            cboAlmacen.SelectedIndex = -1
        End If
        txtFactura.Clear()
        txtIva.Clear()
        txtImporte.Clear()
        txtKilos.Clear()
        txtLitros.Clear()
        txtBarriles.Clear()
        txtDensidad.Clear()
        txtDensidadPLC.Clear()
        DatosSalvados = False
    End Sub

    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboCorporativoDestino.Text <> "" And cboAlmacen.Text <> "" And txtFactura.Text <> "" And _
        txtIva.Text <> "" And txtImporte.Text <> "" And txtKilos.Text <> "" And txtLitros.Text <> "" And _
        txtBarriles.Text <> "" And txtDensidad.Text <> "" And txtDensidadPLC.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Carga el producto del almacen destino
    Private Sub CargarProducto(ByVal AlmacenGas As Integer)
        If AlmacenGas > 0 Then
            Dim oProducto As New PortatilClasses.Consulta.cProductoContenedor(0, AlmacenGas)
            oProducto.CargaDatos()
            Producto = oProducto.Identificador
            oProducto = Nothing
        End If
    End Sub

    ' Checa si las existencia del almacen destino no rebasan el stock minimo que tiene asignado
    Private Function StockMinimo(ByVal AlmacenGas As Integer, ByVal Litros As Decimal) As Boolean
        Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(1, AlmacenGas)
        If oAlmacenGasStock.drReader.Read() Then
            If Litros > CType(oAlmacenGasStock.drReader(1), Decimal) Then
                oAlmacenGasStock.drReader.Close()
                oAlmacenGasStock.CerrarConexion()
                Return False
            End If
        Else
            oAlmacenGasStock.drReader.Close()
            oAlmacenGasStock.CerrarConexion()
            Return False
        End If
        oAlmacenGasStock.drReader.Close()
        oAlmacenGasStock.CerrarConexion()
        Return True
    End Function

    Private Sub ExisteDucto(ByVal Factura As String)
        Dim oDucto As New PortatilClasses.Consulta.cExisteDucto(0)
        oDucto.CargarDatos(Factura, Ducto)
        If oDucto.Factura <> "" Then
            Dim Mensajes As New PortatilClasses.Mensaje(77)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mensajes = Nothing
            txtFactura.Clear()
            ActiveControl = txtFactura
        End If
        NumEnter = 2
    End Sub

    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As DateTime
        Dim Fecha As DateTime
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Registra el producto en la tabla de MovimientoAlmacenproducto
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
        Dim Litros As Decimal
        Litros = CType(txtLitros.Text, Decimal)
        Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
        oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(1, Almacen, Producto, _
                                        MovimientoAlmacen, Litros, Litros, 1)
        oMovimientoAProducto.CargaDatos()
    End Sub

    ' Registra la iformacion de la entrada por ducto
    Private Sub RegistrarDucto(ByVal MovimientoAlmacenE As Integer, ByVal AlmacenGas As Integer, _
    ByVal LitrosPemex As Decimal, ByVal FInicio As DateTime)
        Dim oDucto As New PortatilClasses.Consulta.cDucto(0)
        oDucto.Registrar(0, FInicio, dtpHFinal.Value, CType(txtKilos.Text, Decimal), LitrosPemex, txtFactura.Text, _
               dtpFFactura.Value.Date, CType(txtImporte.Text, Decimal), CType(txtIva.Text, Decimal), _
               CType(cboCorporativoDestino.Identificador, Short), CType(Producto, Short), AlmacenGas, _
               MovimientoAlmacenE, CType(txtBarriles.Text, Decimal), CType(txtDensidad.Text, Decimal), CType(txtDensidadPLC.Text, Decimal), GLOBAL_Usuario)
        oDucto = Nothing
    End Sub

    ' Modifica la iformacion de la entrada por ducto
    Private Sub ModificarEmbarque(ByVal FInicio As DateTime)
        Dim oDucto As New PortatilClasses.Consulta.cDucto(2)
        oDucto.Registrar(Ducto, FInicio, dtpHFinal.Value, CType(txtKilos.Text, Decimal), 0, txtFactura.Text, _
               dtpFFactura.Value.Date, CType(txtImporte.Text, Decimal), CType(txtIva.Text, Decimal), _
               0, 0, 0, 0, CType(txtBarriles.Text, Decimal), CType(txtDensidad.Text, Decimal), CType(txtDensidadPLC.Text, Decimal))
        oDucto = Nothing
    End Sub

    ' Realiza los movimientos del embarque
    Private Sub RealizarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()

            Dim Litros As Decimal
            Dim Kilos As Decimal
            Dim FechaMov As DateTime
            FechaMov = dtpFMovimiento.Value
            Litros = CType(txtLitros.Text, Decimal)
            Kilos = Litros * CType(FactorDensidad, Decimal)

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacen.Identificador, 0, 15, 0)

            Dim oMovimientoAlmacenE As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, cboAlmacen.Identificador, _
                                           FechaMov, Kilos, Litros, 15, dtpHInicio.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenE.Identificador)
            RegistrarDucto(oMovimientoAlmacenE.Identificador, cboAlmacen.Identificador, CType(txtLitros.Text, Decimal), _
                              dtpHInicio.Value)

            'Llama a la pantalla de Captura Medicion "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                frmCapturaMedicion.AlmacenarInformacion(oMovimientoAlmacenE.Identificador, "MOVIMIENTO")
            End If

            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing

            Limpiar()
            DatosSalvados = True
            Close()
        End If
    End Sub

    ' Verfica la información para poder modificarla
    Private Sub ModificarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            ModificarEmbarque(dtpHInicio.Value)
            Limpiar()
            Ducto = 0
            DatosSalvados = True
            Close()
        End If
    End Sub

    ' Verifica la información para poder registrar el embarque
    Private Sub ValidarMovimientos()
        If StockMinimo(cboAlmacen.Identificador, CType(txtLitros.Text, Decimal)) Then
            'Valida que las mediciones fisicas hayan sido correctas "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                If MedicionFisica() Then
                    RealizarMovimientos()
                End If
            Else
                RealizarMovimientos()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(5)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Habilita o Deshabilita los controles que no se pueden modificar
    Private Sub HabilitarControles(ByVal Habilitar As Boolean)
        cboCorporativoDestino.Enabled = Habilitar
        cboAlmacen.Enabled = Habilitar
        dtpFMovimiento.Enabled = Habilitar
        txtLitros.ReadOnly = Not Habilitar
    End Sub

    ' Carga los datos del embarque a los controles correspondientes
    Private Sub CargarDatos(ByVal Ducto As Integer)
        Dim oDucto As New PortatilClasses.Consulta.cDucto(1)
        oDucto.Consultar(Ducto)
        If oDucto.drAlmacen.Read() Then
            cboCorporativoDestino.PosicionaCombo(CType(oDucto.drAlmacen(8), Integer))
            cboAlmacen.CargaDatos(4, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
            cboAlmacen.PosicionaCombo(CType(oDucto.drAlmacen(10), Integer))
            dtpFMovimiento.Value = CType(oDucto.drAlmacen(13), DateTime)
            dtpHInicio.Value = CType(oDucto.drAlmacen(0), DateTime)
            dtpHFinal.Value = CType(oDucto.drAlmacen(1), DateTime)
            txtFactura.Text = CType(oDucto.drAlmacen(4), String)
            dtpFFactura.Value = CType(oDucto.drAlmacen(5), DateTime)
            txtIva.Text = CType(oDucto.drAlmacen(6), String)
            txtImporte.Text = CType(oDucto.drAlmacen(7), String)
            txtKilos.Text = CType(oDucto.drAlmacen(2), String)
            txtLitros.Text = CType(oDucto.drAlmacen(3), String)
            txtBarriles.Text = CType(oDucto.drAlmacen(11), String)
            txtDensidad.Text = CType(oDucto.drAlmacen(12), String)

            If oDucto.drAlmacen(14) Is System.DBNull.Value Then
                txtDensidadPLC.Text = ""
            Else
                txtDensidadPLC.Text = CType(oDucto.drAlmacen(14), String)
            End If

            ActiveControl = dtpHInicio
        End If
        oDucto.drAlmacen.Close()
        oDucto.CerrarConexion()
        oDucto = Nothing
    End Sub

    Private Sub frmDucto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Limpiar()
        dtpFMovimiento.Value = FechaActual()
        dtpHInicio.Value = dtpFMovimiento.Value
        dtpFFactura.Value = dtpFMovimiento.Value
        ActiveControl = cboCorporativoDestino
        cboCorporativoDestino.CargaDatos(0)
        cboCorporativoDestino.PosicionaCombo(GLOBAL_Empresa)
        If cboCorporativoDestino.Text <> "" Then
            cboAlmacen.CargaDatos(4, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
        End If
        If Operacion = "Modificar" Then
            CargarDatos(Ducto)
            HabilitarControles(False)
        End If
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim
        Cursor = Cursors.Default
    End Sub

    Private Sub cboCorporativoDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCorporativoDestino.SelectedIndexChanged
        If cboCorporativoDestino.Focused And cboCorporativoDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboAlmacen.CargaDatos(4, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
            If cboAlmacen.Identificador > 0 Then
                CargarProducto(cboAlmacen.Identificador)
            End If
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.SelectedIndexChanged
        If cboAlmacen.Focused Then
            Cursor = Cursors.WaitCursor
            HabilitarAceptar()
            CargarProducto(cboAlmacen.Identificador)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCorporativoDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboCorporativoDestino.KeyDown, cboAlmacen.KeyDown, dtpFMovimiento.KeyDown, dtpHInicio.KeyDown, _
    dtpHFinal.KeyDown, dtpFFactura.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtIva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtIva.KeyDown, txtImporte.KeyDown, txtKilos.KeyDown, txtLitros.KeyDown, _
    txtBarriles.KeyDown, txtDensidad.KeyDown, txtDensidadPLC.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub dtpFMovimiento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFMovimiento.TextChanged, dtpHFinal.TextChanged, dtpFFactura.TextChanged, txtIva.TextChanged, _
    txtImporte.TextChanged, txtKilos.TextChanged, txtLitros.TextChanged, txtBarriles.TextChanged, _
    txtDensidad.TextChanged, txtDensidadPLC.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub dtpHInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpHInicio.TextChanged
        dtpHFinal.MinDate = dtpHInicio.Value
        HabilitarAceptar()
    End Sub

    Private Sub txtFactura_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtFactura.TextChanged
        NumEnter = 1
        HabilitarAceptar()
    End Sub

    Private Sub txtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtFactura.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub txtDensidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDensidad.Leave
        If txtDensidad.Text <> "" Then
            If CType(txtDensidad.Text, Decimal) >= 1 Then
                Dim Mensajes As New PortatilClasses.Mensaje(10)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = txtDensidad
            Else
                If txtKilos.Text <> "" And txtDensidad.Text <> "" Then
                    Dim Litros As Double
                    Litros = CType(txtKilos.Text, Decimal) / CType(txtDensidad.Text, Decimal)
                    txtLitros.Text = Format(Litros, "n2")
                End If
                'If txtLitros.Text <> "" Then
                '    Dim Barriles As Double
                '    Barriles = CType(txtLitros.Text, Decimal) / 158.98
                '    txtBarriles.Text = Format(Barriles, "n2")
                'End If
            End If
        End If
    End Sub

    Private Sub txtFactura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFactura.Leave
        'If NumEnter = 1 And txtFactura.Text <> "" And txtFactura.Focused Then
        '    ExisteDucto(txtFactura.Text)
        'End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        ' 20060617CAGP$005 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
        cboAlmacen.Identificador, 0) ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            CargarProducto(cboAlmacen.Identificador)
            If Operacion = "Agregar" Then
                ValidarMovimientos()
            End If
            If Operacion = "Modificar" Then
                ModificarMovimientos()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
        ' 20060617CAGP$005 /F
        Cursor = Cursors.Default
    End Sub

    Private Sub txtKilos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtKilos.Leave
        If txtKilos.Text <> "" And txtDensidad.Text <> "" Then
            Dim Litros As Double
            Litros = CType(txtKilos.Text, Decimal) / CType(txtDensidad.Text, Decimal)
            txtLitros.Text = Format(Litros, "n2")
        End If

        'If txtLitros.Text <> "" Then
        '    Dim Barriles As Double
        '    Barriles = CType(txtLitros.Text, Decimal) / 158.98
        '    txtBarriles.Text = Format(Barriles, "n2")
        'End If
    End Sub

End Class
