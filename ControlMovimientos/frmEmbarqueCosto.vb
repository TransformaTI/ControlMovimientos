' En esta forma podemos consultar y actualizar los costo del embarque, ya sea en costo por kilo o el costo del
' flete por kilo, no se calcula automaticamente porque puede haber varios precios por kilos eimpuestos 

Public Class frmEmbarqueCosto
    Inherits System.Windows.Forms.Form

    Private Embarque As Integer
    Private Titulo As String
    Private DatosSalvados As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _Embarque As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Embarque = _Embarque
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents cboZEconomica As PortatilClasses.Combo.ComboZEconomicaPtl
    Friend WithEvents lblFlete As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lblKilosPemex As System.Windows.Forms.Label
    Friend WithEvents lblTransportadora As System.Windows.Forms.Label
    Friend WithEvents lblFEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblCorporativoF As System.Windows.Forms.Label
    Friend WithEvents lblEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents lblPrecioFlete As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEmbarqueCosto))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblPrecioFlete = New System.Windows.Forms.Label()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.cboZEconomica = New PortatilClasses.Combo.ComboZEconomicaPtl()
        Me.lblFlete = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblKilosPemex = New System.Windows.Forms.Label()
        Me.lblTransportadora = New System.Windows.Forms.Label()
        Me.lblFEmbarque = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblCorporativoF = New System.Windows.Forms.Label()
        Me.lblEmbarque = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFactura, Me.Label3, Me.lblPrecioFlete, Me.cboProducto, Me.cboZEconomica, Me.lblFlete, Me.lblIva, Me.lblImporte, Me.lblKilosPemex, Me.lblTransportadora, Me.lblFEmbarque, Me.lblAlmacen, Me.lblCorporativoF, Me.lblEmbarque, Me.Label6, Me.Label5, Me.Label4, Me.lblCosto, Me.Label2, Me.Label1, Me.Label43, Me.Label15, Me.Label18, Me.Label19, Me.Label21, Me.Label22})
        Me.grpDatos.Location = New System.Drawing.Point(16, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 374)
        Me.grpDatos.TabIndex = 10
        Me.grpDatos.TabStop = False
        '
        'lblPrecioFlete
        '
        Me.lblPrecioFlete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrecioFlete.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblPrecioFlete.Location = New System.Drawing.Point(363, 252)
        Me.lblPrecioFlete.Name = "lblPrecioFlete"
        Me.lblPrecioFlete.Size = New System.Drawing.Size(106, 21)
        Me.lblPrecioFlete.TabIndex = 109
        Me.lblPrecioFlete.Text = "lblPrecioFlete"
        Me.lblPrecioFlete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblPrecioFlete, "Costo del flete por kilo transportado")
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(149, 308)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(216, 21)
        Me.cboProducto.TabIndex = 1
        '
        'cboZEconomica
        '
        Me.cboZEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEconomica.Location = New System.Drawing.Point(149, 336)
        Me.cboZEconomica.Name = "cboZEconomica"
        Me.cboZEconomica.Size = New System.Drawing.Size(216, 21)
        Me.cboZEconomica.TabIndex = 2
        '
        'lblFlete
        '
        Me.lblFlete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlete.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblFlete.Location = New System.Drawing.Point(149, 252)
        Me.lblFlete.Name = "lblFlete"
        Me.lblFlete.Size = New System.Drawing.Size(211, 21)
        Me.lblFlete.TabIndex = 108
        Me.lblFlete.Text = "lblFlete"
        Me.lblFlete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIva
        '
        Me.lblIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIva.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblIva.Location = New System.Drawing.Point(149, 223)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(211, 21)
        Me.lblIva.TabIndex = 107
        Me.lblIva.Text = "lblIva"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporte
        '
        Me.lblImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblImporte.Location = New System.Drawing.Point(149, 195)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(211, 21)
        Me.lblImporte.TabIndex = 106
        Me.lblImporte.Text = "lblImporte"
        Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilosPemex
        '
        Me.lblKilosPemex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilosPemex.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblKilosPemex.Location = New System.Drawing.Point(149, 167)
        Me.lblKilosPemex.Name = "lblKilosPemex"
        Me.lblKilosPemex.Size = New System.Drawing.Size(211, 21)
        Me.lblKilosPemex.TabIndex = 105
        Me.lblKilosPemex.Text = "lblKilosPemex"
        Me.lblKilosPemex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransportadora
        '
        Me.lblTransportadora.AutoSize = True
        Me.lblTransportadora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTransportadora.Location = New System.Drawing.Point(149, 139)
        Me.lblTransportadora.Name = "lblTransportadora"
        Me.lblTransportadora.Size = New System.Drawing.Size(90, 13)
        Me.lblTransportadora.TabIndex = 104
        Me.lblTransportadora.Text = "lblTransportadora"
        Me.lblTransportadora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFEmbarque
        '
        Me.lblFEmbarque.AutoSize = True
        Me.lblFEmbarque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblFEmbarque.Location = New System.Drawing.Point(149, 111)
        Me.lblFEmbarque.Name = "lblFEmbarque"
        Me.lblFEmbarque.Size = New System.Drawing.Size(70, 13)
        Me.lblFEmbarque.TabIndex = 103
        Me.lblFEmbarque.Text = "lblFEmbarque"
        Me.lblFEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblAlmacen.Location = New System.Drawing.Point(149, 83)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(56, 13)
        Me.lblAlmacen.TabIndex = 102
        Me.lblAlmacen.Text = "lblAlmacen"
        Me.lblAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCorporativoF
        '
        Me.lblCorporativoF.AutoSize = True
        Me.lblCorporativoF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCorporativoF.Location = New System.Drawing.Point(149, 55)
        Me.lblCorporativoF.Name = "lblCorporativoF"
        Me.lblCorporativoF.Size = New System.Drawing.Size(77, 13)
        Me.lblCorporativoF.TabIndex = 101
        Me.lblCorporativoF.Text = "lblCorporativoF"
        Me.lblCorporativoF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmbarque
        '
        Me.lblEmbarque.AutoSize = True
        Me.lblEmbarque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEmbarque.Location = New System.Drawing.Point(149, 27)
        Me.lblEmbarque.Name = "lblEmbarque"
        Me.lblEmbarque.Size = New System.Drawing.Size(64, 13)
        Me.lblEmbarque.TabIndex = 100
        Me.lblEmbarque.Text = "lblEmbarque"
        Me.lblEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(16, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Costo del flete:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(16, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Iva:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(16, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Importe:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCosto
        '
        Me.lblCosto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCosto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCosto.Location = New System.Drawing.Point(363, 195)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(106, 21)
        Me.lblCosto.TabIndex = 96
        Me.lblCosto.Text = "lblCosto"
        Me.lblCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblCosto, "Costo por kilos")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Producto:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 340)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Zona económica"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label43.Location = New System.Drawing.Point(16, 168)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(66, 13)
        Me.Label43.TabIndex = 93
        Me.Label43.Text = "Kilos Pemex:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(16, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Transportadora:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label18.Location = New System.Drawing.Point(16, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Fecha embarque:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label19.Location = New System.Drawing.Point(16, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 89
        Me.Label19.Text = "Número embarque:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label21.Location = New System.Drawing.Point(16, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "Empresa a facturar:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label22.Location = New System.Drawing.Point(16, 83)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 13)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "Contenedor de gas:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(515, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(515, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Factura:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFactura
        '
        Me.txtFactura.AutoSize = False
        Me.txtFactura.Location = New System.Drawing.Point(149, 280)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(216, 21)
        Me.txtFactura.TabIndex = 0
        Me.txtFactura.Text = "TextBox1"
        '
        'frmEmbarqueCosto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 400)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEmbarqueCosto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmEmbarqueCosto"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        lblFlete.Text = "0.00"
        lblIva.Text = "0.00"
        lblImporte.Text = "0.00"
        lblKilosPemex.Text = "0.00"
        lblTransportadora.Text = ""
        lblFEmbarque.Text = ""
        lblAlmacen.Text = ""
        lblCorporativoF.Text = ""
        lblEmbarque.Text = ""
        lblCosto.Text = "0.00"
        lblPrecioFlete.Text = "0.00"
        If cboProducto.Items.Count > 1 Then
            cboProducto.PosicionarInicio()
        End If
        If cboZEconomica.Items.Count > 1 Then
            cboZEconomica.PosicionarInicio()
        End If
        txtFactura.Clear()
        DatosSalvados = False
    End Sub

    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboProducto.Text <> "" And cboZEconomica.Text <> "" And lblImporte.Text <> "0.00" And _
        txtFactura.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Carga el precio dependiendo del producto seleccionado y de la zona economica
    Private Sub CargarPrecio()
        Cursor = Cursors.WaitCursor
        If cboProducto.Text <> "" And cboZEconomica.Text <> "" Then
            Dim oPrecio As New PortatilClasses.Consulta.cPrecio(0, cboProducto.Identificador, _
                                                                cboZEconomica.Identificador)
            oPrecio.CargaDatos()
            lblCosto.Text = CType(oPrecio.Costo, String)
            lblCosto.Tag = CType(oPrecio.Impuesto, Decimal)
            lblPrecioFlete.Text = CType(oPrecio.Flete, String)
            CargarFlete(oPrecio.Flete)
            CargarCosto(oPrecio.Costo)
            oPrecio = Nothing
        End If
        Cursor = Cursors.Default
    End Sub

    ' Calcula el costo del flete del embarque depediendo de los kilos según PEMEX y el flete por cada kilo
    Private Sub CargarFlete(ByVal PrecioFlete As Decimal)
        Cursor = Cursors.WaitCursor
        Dim Flete As Decimal
        Flete = CType(lblKilosPemex.Text, Decimal) * PrecioFlete
        lblFlete.Text = Format(Flete, "n")
        Cursor = Cursors.Default
    End Sub

    ' Calcula el costo del embarque dependiendo de los kilos según PEMEX y el costo del kilo
    Private Sub CargarCosto(ByVal PrecioCosto As Decimal)
        Cursor = Cursors.WaitCursor
        Dim Costo As Decimal
        Dim Iva As Decimal
        Try
            Costo = CType(lblKilosPemex.Text, Decimal) * PrecioCosto
            Iva = Costo - (Costo / (CType(lblCosto.Tag, Decimal) / 100 + 1))
        Catch
            Costo = 0
            Iva = 0
        End Try
        lblImporte.Text = Format(Costo, "n")
        lblIva.Text = Format(Iva, "n")
        Cursor = Cursors.Default
    End Sub

    ' Carga los datos del embarque a los controles correspondientes
    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Dim oEmbarque As New PortatilClasses.Consulta.cEmbarqueCosto(1)
        oEmbarque.Consultar(Embarque)
        If oEmbarque.drAlmacen.Read() Then
            lblEmbarque.Text = CType(oEmbarque.drAlmacen(0), String)
            lblCorporativoF.Text = CType(oEmbarque.drAlmacen(5), String)
            lblAlmacen.Text = CType(oEmbarque.drAlmacen(7), String)
            lblFEmbarque.Text = CType(oEmbarque.drAlmacen(2), String)
            lblTransportadora.Text = CType(oEmbarque.drAlmacen(6), String)
            lblKilosPemex.Text = Format(CType(oEmbarque.drAlmacen(1), Decimal), "n")
            If Not IsDBNull(oEmbarque.drAlmacen(4)) Then
                lblImporte.Text = CType(oEmbarque.drAlmacen(4), String)
            End If
            If Not IsDBNull(oEmbarque.drAlmacen(3)) Then
                lblIva.Text = CType(oEmbarque.drAlmacen(3), String)
            End If
            If Not IsDBNull(oEmbarque.drAlmacen(8)) Then
                lblFlete.Text = CType(oEmbarque.drAlmacen(8), String)
            Else
                lblFlete.Text = "0"
            End If
            If Not IsDBNull(oEmbarque.drAlmacen(9)) Then
                cboZEconomica.PosicionaCombo(CType(oEmbarque.drAlmacen(9), Integer))
            End If
            If Not IsDBNull(oEmbarque.drAlmacen(10)) Then
                cboProducto.PosicionaCombo(CType(oEmbarque.drAlmacen(10), Integer))
            End If
            If Not IsDBNull(oEmbarque.drAlmacen(11)) Then
                txtFactura.Text = CType(oEmbarque.drAlmacen(11), String)
            End If
            CargarPrecio()
        End If
        oEmbarque.drAlmacen.Close()
        oEmbarque.CerrarConexion()
        oEmbarque = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Registra la información de los costos del embarque
    Private Sub ActualizarCostos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            Cursor = Cursors.WaitCursor
            Dim oEmbarque As New PortatilClasses.Consulta.cEmbarqueCosto(0)
            oEmbarque.Registrar(Embarque, CType(lblImporte.Text, Decimal), CType(lblIva.Text, Decimal), CType(lblFlete.Text, Decimal), _
                                cboZEconomica.Identificador, cboProducto.Identificador, txtFactura.Text)
            oEmbarque = Nothing
            DatosSalvados = True
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Inicializa los controles necesarios y variables a utilizar
    Private Sub frmEmbarqueCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        btnAceptar.Enabled = False
        Titulo = "Costo del embarque"
        Me.Text = Titulo
        Limpiar()
        cboZEconomica.CargaDatos(0, GLOBAL_Usuario)
        cboProducto.CargaDatos(1, GLOBAL_Usuario)
        CargarDatos()
        CargarPrecio()
        HabilitarAceptar()
        ActiveControl = txtFactura
        Cursor = Cursors.Default
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboZEconomica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboZEconomica.KeyDown, cboProducto.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Cierra la forma y regrese a la forma donde fue llamada
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    ' Si los valores son cambiados carga los precios de costo y flete de los valores seleccionados, y habilita 
    ' el botón Aceptar si cumple con las condiciones
    Private Sub cboZEconomica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboZEconomica.SelectedIndexChanged, cboProducto.SelectedIndexChanged
        If cboZEconomica.Focused Or cboProducto.Focused Then
            CargarPrecio()
            HabilitarAceptar()
        End If
    End Sub

    ' Actualiza los costos del embarque visualizado
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ActualizarCostos()
    End Sub

    Private Sub frmEmbarqueCosto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFactura.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub txtFactura_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFactura.TextChanged
        HabilitarAceptar()
    End Sub
End Class
