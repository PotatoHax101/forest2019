Structure Tree

    Public _age, _ratio As Integer
    Public _disease, _mapleSyrup As Boolean
    Public _treeType As String

End Structure

Module Module1

    Sub Main()

        treeDistribution()

        Console.Read()

    End Sub

    Function treeDistribution()

        Dim forest(10000) As Tree
        Dim pine As Tree
        Dim oak As Tree

        Dim totalRatio As Integer = ratioCalculation(pine, 4, oak, 1)

        For i = 1 To forest.Length

            'Console.WriteLine(i)

            If i Mod totalRatio = 0 Then

                forest(i - 1)._treeType = "oak"

            Else

                forest(i - 1)._treeType = "pine"

            End If

            Console.WriteLine(forest(i - 1)._treeType)

        Next

        Return forest

    End Function

    Function ratioCalculation(ByRef treeType1 As Tree, ByRef ratio1 As Integer, ByRef treeType2 As Tree, ByRef ratio2 As Integer) 'calculating total ratio, used to work out how to distrib trees

        treeType1._ratio = ratio1
        Console.WriteLine(treeType1._ratio)

        treeType2._ratio = ratio2
        Console.WriteLine(treeType2._ratio)

        Dim totalRatio As Integer = treeType1._ratio + treeType2._ratio
        Console.WriteLine(totalRatio)

        Return totalRatio

    End Function

End Module
