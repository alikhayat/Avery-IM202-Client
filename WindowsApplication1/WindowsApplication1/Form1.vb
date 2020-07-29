Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Public Class Form1
    Dim tcpClient As New System.Net.Sockets.TcpClient()
    Dim networkStream As NetworkStream

    Dim Pl1 As Byte() = {&H0, &H0, &H0, &H33, &H0, &H0, &H5A, &HF1, &H0, &H0, &H0, &H1, &H0, &H0, &H0, &H11, &H63, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H13, &H63, &HFE, &H20, &H49, &H0, &H0, &H3B, &H51, &H0, &H0, &H1, &H1, &H4E, &H7F, &HFF}
    Dim Pl2 As Byte() = {&H0, &H0, &H0, &H36, &H0, &H0, &H5A, &HF1, &H0, &H0, &H0, &H1, &H0, &H0, &H0, &H14, &H63, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HB, &H0, &H16, &H63, &HFE, &H20, &H49, &H0, &H0, &H26, &H51, &H0, &H0, &H1, &H1, &H4E, &H7F, &HFF}
    Dim Pl3 As Byte() = {&H0, &H0, &H0, &H36, &H0, &H0, &H5A, &HF1, &H0, &H0, &H0, &H1, &H0, &H0, &H0, &H14, &H63, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HB, &H0, &H16, &H63, &HFE, &H20, &H49, &H0, &H0, &H26, &H51, &H0, &H0, &H1, &H1, &H4E, &H7F, &HFF}
    Dim PluCmd As Byte() = {&H0, &H0, &H0, &HC3, &H0, &H0, &H5A, &HF1, &H0, &H0, &H0, &H1, &H0, &H0, &H0, &H9A, &H63, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H9A, &H63, &HFF, &H20, &H49, &H0, &H0, &HD, &H55, &H0, &H0, &H1, &H1, &H4E, &H7F, &HFF}
    Dim keyCmd1 As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1C, &H84, &H0, &H4A, &H64, &HFD, &H20, &H49, &H0, &H0, &H78, &H55, &H0, &H0, &H1, &H1, &H4E, &H0, &H0, &H37, &H7E, &H0, &H0, &H0, &H2, &H0, &HF, &H42, &H3F, &H1, &H0, &H0, &H0, &H0, &HB, &H46, &H69, &H78, &H65, &H64, &H20, &H4B, &H65, &H79, &H62, &H6F, &H61, &H74, &H64, &H20, &H20, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H3, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
    Dim KeyCmd2 As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1C, &H84, &H0, &H4B, &H64, &HFD, &H20, &H49, &H0, &H0, &H77, &H55, &H0, &H0, &H1, &H1, &H4E, &H0, &H0}
    Dim Dplu As Byte() = {&H0, &H0, &H0, &H5C, &H0, &H0, &H5A, &HF1, &H0, &H0, &H0, &H1, &H0, &H0, &H0, &H3A, &H63, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H63, &HFF, &H20, &H49, &H0, &H0, &HD, &H43, &H0, &H0, &H1, &H1, &H4E, &H7F, &HFF}
    Dim GetP As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H64, &HFE, &H20, &H49, &H0, &H0, &HD, &H51, &H0, &H0, &H1, &H1, &H4E, &H0, &H0, &H2D, &HB0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1, &H9, &H0, &H9, &H18, &H4E, &H72, &H9F, &HFF, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H63}
    Dim RetV As Byte()
    Dim PluNo As String = ""
    Dim Barcode As String = ""
    Dim Price As String = ""
    Dim LifeCycle As String = ""
    Dim Uom As String = ""
    Dim Uom2 As String = ""
    Dim Lenght As String = ""
    Dim Desc As String = ""
    Dim DescAr As String = ""
    Dim Btn As String = ""
    Dim identifier As Integer = 0
    Dim IsDesc As Boolean = False
    Dim test As Byte()




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        identifier = 1
        'Get Vars from user
        Dim PluQ As Integer = InputBox("Input Plu's quantity", "Input Plu's quantity")
        For i As Integer = 0 To PluQ - 1
            PluNo = InputBox("Input Plu No", "Input Plu No")
            Barcode = InputBox("Input Barcode", "Input Barcode")
            Barcode = Barcode + "0000000"
            Price = InputBox("Input Price", "Input Price")
            LifeCycle = InputBox("Input LifeCycle", "Input LifeCycle")
            Uom = InputBox("Input Unit Of Measure 4=Kg, 5=Piece", "Input Unit Of Measure 4=Kg, 5=Piece")

            While Uom <> "4" OrElse Uom <> "5"

                If Uom = "4" Or Uom = "5" Then
                    Exit While
                Else
                    Uom = InputBox("Input Unit Of Measure 4=Kg, 5=Piece", "Input Unit Of Measure 4=Kg, 5=Piece")
                End If
            End While

            If Uom = "4" Then
                Uom2 = "0"
            Else
                Uom2 = "1"
            End If
            

            Desc = InputBox("Input Description", "Input Description")
            DescAr = InputBox("Input arabic description", "Input arabic description")

            'Produce two random hex values and add them to pl1, 2, 3 and plucmd arrays
            Randomize()
            Dim RandNb As Integer = CInt(Int((65535 * Rnd()) + 4096))
            Dim RandStore As Integer = RandNb
            Dim RandHex1 As String = "&H" + Hex(RandStore).Substring(0, 2)
            Dim RandHex2 As String = "&H" + Hex(RandStore).Substring(2, 2)

            RandStore += 1
            Dim RandHex3 As String = "&H" + Hex(RandStore).Substring(2, 2)

            RandStore += 1
            Dim RandHex4 As String = "&H" + Hex(RandStore).Substring(2, 2)

            RandStore += 1
            Dim RandHex5 As String = "&H" + Hex(RandStore).Substring(2, 2)

            'pl1 command completion
            Pl1 = Pl1.Concat({RandHex1}).ToArray
            Pl1 = Pl1.Concat({RandHex2}).ToArray


            'pl2 command completion
            Pl2 = Pl2.Concat({RandHex1}).ToArray
            Pl2 = Pl2.Concat({RandHex3}).ToArray
            Pl2 = Pl2.Concat({"&H1"}).ToArray
            Pl2 = Pl2.Concat({"&H1"}).ToArray
            Pl2 = Pl2.Concat({"&H0"}).ToArray


            'pl3 command completion
            Pl3 = Pl3.Concat({RandHex1}).ToArray
            Pl3 = Pl3.Concat({RandHex4}).ToArray
            Pl3 = Pl3.Concat({"&H4"}).ToArray
            Pl3 = Pl3.Concat({"&HA"}).ToArray
            Pl3 = Pl3.Concat({"&H0"}).ToArray


            'plucmd completion
            'convert taken vars to hex values
            PluNo = StringToHexN(PluNo)
            Barcode = StringToHexN(Barcode)
            Price = StringToHexN(Price)
            LifeCycle = StringToHexN(LifeCycle)
            'Uom = StringToHexN(Uom)
            Uom2 = StringToHexN(Uom2)
            Desc = DescToHex(Desc)
            DescAr = ArDesc(DescAr)




            'Generate actual Plu Command

            PluCmd = PluCmd.Concat({RandHex1}).ToArray
            PluCmd = PluCmd.Concat({RandHex5}).ToArray
            PluZeros(PluNo)

            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            
            StringToBytes(PluNo)
            PluZeros(PluNo)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            
            StringToBytes(PluNo)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(Barcode)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(Barcode)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluZeros(PluNo)
            
            
            StringToBytes(PluNo)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(Price)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H02"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(Barcode)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(LifeCycle)
            PluCmd = PluCmd.Concat({"&H01"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H01"}).ToArray
            'StringToBytes(Uom)

            If Uom = "4" Then
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
            ElseIf Uom = "5" Then
                PluCmd = PluCmd.Concat({"&H10"}).ToArray
            End If

            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H02"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&Hff"}).ToArray
            PluCmd = PluCmd.Concat({"&Hfe"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H01"}).ToArray
            PluCmd = PluCmd.Concat({"&H02"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            StringToBytes(Uom2)
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray


            StringToBytes(DescAr)
            'PluCmd = PluCmd.Concat({"&H62"}).ToArray
            PluCmd = PluCmd.Concat({"&H0a"}).ToArray


            StringToBytes(Desc)
            'PluCmd = PluCmd.Concat({"&H43"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray
            PluCmd = PluCmd.Concat({"&H0"}).ToArray

            'Enter plu command length
            Lenght = StringToHexN(PluCmd.Length.ToString)
            PluCmd(3) = Lenght

            Lenght = Lenght - 32
            PluCmd(33) = "&H" + Hex(Lenght)
            If networkStream.CanWrite And networkStream.CanRead Then
                ' send commands to scale 
                
                tcpClient.NoDelay = False
                networkStream.Write(Pl1, 0, Pl1.Length)
                networkStream.Write(Pl2, 0, 54)
                Dim inStream(tcpClient.ReceiveBufferSize) As Byte
                networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
                networkStream.Write(Pl3, 0, 54)
                networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
                networkStream.Write(PluCmd, 0, PluCmd.Length)
                networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
                tcpClient.Close()



                ' READ
                '    Dim inStream(tcpClient.ReceiveBufferSize) As Byte
                '    networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
                '    Dim returndata As String = _
                'System.Text.Encoding.ASCII.GetString(inStream)
                '    MsgBox("Data from Server : " + returndata)
                '    networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
                '    returndata = _
                'System.Text.Encoding.ASCII.GetString(inStream)
                '    MsgBox("Data from Server : " + returndata)


            End If
        Next
    End Sub


   
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Establish a connection with the Scale 
        tcpClient.Connect("10.3.5.9", 3001)
        networkStream = tcpClient.GetStream()
        retrieve()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        identifier = 3
        'Take Plu from user
        PluNo = InputBox("Enter a plu to be deleted")

        'Produce two random hex values and add them to Dplu
        Randomize()
        Dim RandNb As Integer = CInt(Int((65535 * Rnd()) + 4096))
        Dim RandStore As Integer = RandNb
        Dim RandHex1 As String = "&H" + Hex(RandStore).Substring(0, 2)
        Dim RandHex2 As String = "&H" + Hex(RandStore).Substring(2, 2)
        Dplu = Dplu.Concat({RandHex1}).ToArray
        Dplu = Dplu.Concat({RandHex2}).ToArray

        'Dplu completion
        PluNo = StringToHexN(PluNo)
        PluZeros2(PluNo)
        StringToBytes(PluNo)

        PluZeros2(PluNo)
        StringToBytes(PluNo)

        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H0"}).ToArray
        Dplu = Dplu.Concat({"&H63"}).ToArray

        If networkStream.CanWrite And networkStream.CanRead Then
            ' send commands to scale 

            tcpClient.NoDelay = False
            networkStream.Write(Dplu, 0, Dplu.Length)

            Dim inStream(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
            
            tcpClient.Close()

        End If
    End Sub
    
    Function StringToHexN(ByVal text As String) As String
        'For numbers
        'convert to hex
        text = Hex(text)

        'if the hex output is odd add a zero at the start
        If text.Length Mod 2 <> 0 Then
            text = "0" + text
        End If

        ' add &H to hex values 
        Dim builder As New StringBuilder(text)
        Dim startIndex = builder.Length - (builder.Length Mod 2)

        For s As Int32 = startIndex To 2 Step -2
            builder.Insert(s, "&H")
        Next s
        text = "&H" + builder.ToString()

        'delete &H from the end of the hex vlaue if found 
        Dim i As Integer = text.Length
        If text.Chars(i - 1) = "H" And text.Chars(i - 2) = "&" Then
            text = text.Substring(0, text.Length - 2)
        End If
        Return text

    End Function
    Function StringToBytes(ByVal text As String)
        'this function seperates the hex values each piece is 4 chars long unless we have an even number the last piece would be 3
        ' Test if even or odd with integer "a" if odd then round the 0.5 to 0, as if the result is 3.5 returns 3
        Dim a As Integer = text.Length Mod 2
        Dim c As Integer = 0
        Dim steps As Integer = 0
        If IsDesc = True Then
            steps = 5
        Else
            steps = 4
        End If
        Dim i As Integer = 0
        If a = 1 Then
            a = text.Length / 4
            a = Math.Round(a)
        End If
        'get the hex pieces and add them to PLuCmd array
        For s As Integer = 0 To text.Length - 1 Step steps
            Dim o As Integer = 4
            i += 1
            Dim B As String = ""

            If i = a Then
                o = 3
            End If

            Try
                B = text.Substring(s, o)
                If identifier = 1 Then
                    PluCmd = PluCmd.Concat({B}).ToArray
                ElseIf identifier = 2 Then
                    KeyCmd2 = KeyCmd2.Concat({B}).ToArray
                ElseIf identifier = 3 Then
                    Dplu = Dplu.Concat({B}).ToArray
                End If

            Catch ex As Exception

            End Try

        Next s
        Return Nothing
    End Function
    Function PluZeros(ByVal text As String)

        Select Case text.Length
            Case 3 To 4
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
            Case 6 To 8
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
            Case 11 To 12
                PluCmd = PluCmd.Concat({"&H0"}).ToArray
        End Select
        Return Nothing
    End Function
    Function DescToHex(ByVal desc As String) As String
        Dim clone As String = desc
        desc = String.Empty
        For Each c As Char In clone
            If Char.IsNumber(c) = True Then
                Dim i = Hex(Asc(c))
                desc += i
            Else
                Dim i = Convert.ToInt32(Hex(Asc(c)), 16) + 117
                desc += Hex(i)
            End If


        Next


        ' add &H to hex values 
        Dim builder As New StringBuilder(desc)
        Dim startIndex = builder.Length - (builder.Length Mod 2)

        For s As Int32 = startIndex To 2 Step -2
            builder.Insert(s, "&H")
        Next s
        desc = "&H" + builder.ToString()

        'delete &H from the end of the hex vlaue if found 
        Dim a As Integer = desc.Length
        If desc.Chars(a - 1) = "H" And desc.Chars(a - 2) = "&" Then
            desc = desc.Substring(0, desc.Length - 2)
        End If
        Return desc
    End Function
    Function ArDesc(ByVal desc As String) As String
        Dim clone As String = desc
        desc = String.Empty
        For Each c As Char In clone
            If Char.IsNumber(c) = True Then
                Dim i = Hex(Asc(c))
                desc += i
            Else
                Dim i = Convert.ToInt32(Hex(Asc(c)), 16) - 96
                desc += Hex(i)
            End If
        Next


        ' add &H to hex values 
        Dim builder As New StringBuilder(desc)
        Dim startIndex = builder.Length - (builder.Length Mod 2)

        For s As Int32 = startIndex To 2 Step -2
            builder.Insert(s, "&H")
        Next s
        desc = "&H" + builder.ToString()

        'delete &H from the end of the hex vlaue if found 
        Dim a As Integer = desc.Length
        If desc.Chars(a - 1) = "H" And desc.Chars(a - 2) = "&" Then
            desc = desc.Substring(0, desc.Length - 2)
        End If
        Return desc
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        identifier = 2
        'Take input from user
        Btn = InputBox("Enter button identifier (1-84),Enter button identifier (1-84)")
        PluNo = InputBox("Enter a Plu number", "Please enter a Plu number")

        'Produce two random hex values and add them to KeyCmd1 and 2
        Randomize()
        Dim RandNb As Integer = CInt(Int((65535 * Rnd()) + 4096))
        Dim RandStore As Integer = RandNb
        Dim RandHex1 As String = "&H" + Hex(RandStore).Substring(0, 2)
        Dim RandHex2 As String = "&H" + Hex(RandStore).Substring(2, 2)

        keyCmd1(49) = RandHex1
        keyCmd1(50) = RandHex2

        RandStore += 1
        Dim RandHex3 As String = "&H" + Hex(RandStore).Substring(2, 2)

        KeyCmd2 = KeyCmd2.Concat({RandHex1}).ToArray
        KeyCmd2 = KeyCmd2.Concat({RandHex3}).ToArray

        'KeyCmd2 Completion
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0b"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H01"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray

        Btn = StringToHexN(Btn)
        StringToBytes(Btn)
        KeyCmd2 = KeyCmd2.Concat({"&H01"}).ToArray 'Must be replaced with another value if we aren't assigning a plu
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray  ''Must be replaced with another value if we are assigning in a different group
        

        PluNo = StringToHexN(PluNo)
        PluZeros2(PluNo)
        StringToBytes(PluNo)
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
        KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray

        


        If networkStream.CanWrite And networkStream.CanRead Then
            ' send commands to scale 

            tcpClient.NoDelay = False
            networkStream.Write(keyCmd1, 0, keyCmd1.Length)

            Dim inStream(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))
            networkStream.Write(KeyCmd2, 0, KeyCmd2.Length)
            networkStream.Read(inStream, 0, CInt(tcpClient.ReceiveBufferSize))

            tcpClient.Close()

        End If
        
    End Sub
    Function PluZeros2(ByVal text As String)

        Select Case text.Length
            Case 7 To 8
                If identifier = 2 Then
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                ElseIf identifier = 3 Then
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                End If
            Case 11 To 12
                If identifier = 2 Then
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray
                    KeyCmd2 = KeyCmd2.Concat({"&H0"}).ToArray

                ElseIf identifier = 3 Then
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray
                    Dplu = Dplu.Concat({"&H0"}).ToArray

                End If

        End Select
        Return Nothing
    End Function

    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
    Private Sub retrieve()

        Dim pl As Integer = -1

        

        Dim inStream(tcpClient.ReceiveBufferSize) As Byte

        'While inStream.Length <> 51
        pl += 1
        GetP(86) = "&H" + pl.ToString("x2")

        If networkStream.CanWrite Then
            tcpClient.NoDelay = False
            networkStream.Write(GetP, 0, GetP.Length)
        End If

        Dim bytes(8192 - 1) As Byte
        Dim bytesRead As Integer = networkStream.Read(bytes, 0, bytes.Length)

        Dim returndata As String = "{"

        'Convert each byte into a hex string, separated by commas.
        For x = 0 To bytesRead - 1
            returndata &= bytes(x).ToString("X") & If(x < bytesRead - 1, ", ", "}")
        Next

        Dim words As String() = returndata.Split(New Char() {","c})
        
        MsgBox(Convert.ToInt64(words(99)))

        'End While




        tcpClient.Close()




    End Sub
End Class
