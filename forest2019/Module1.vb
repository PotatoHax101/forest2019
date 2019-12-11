Structure Tree

    Public _age, _ratio As Integer
    Public _disease, _mapleSyrup, _onFire As Boolean
    Public _treeType As String

End Structure

Module Module1

    Sub Main()

        treeDistribution()


        Console.Read()

    End Sub

    Function treeDistribution()

        Dim forest(100, 100) As Tree 'Dimensions: 0, 1
        Dim pine As Tree
        Dim oak As Tree

        Dim totalRatio As Integer = ratioCalculation(pine, 4, oak, 1)
        Dim forestUpper As Integer = forest.GetUpperBound(0) 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) 'Getting second dimension of 2D array

        Dim randNum As New Random()


        For i = 1 To forestUpper

            For q = 1 To forestLower

                If q Mod totalRatio = 0 Then

                    forest(i - 1, q - 1)._treeType = "oak"

                Else

                    forest(i - 1, q - 1)._treeType = "pine"

                End If

                forest(i - 1, q - 1)._age = randNum.Next(1, 201)

                Console.WriteLine(forest(i - 1, q - 1)._age)

            Next

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

    Sub management(ByRef pine As Tree, ByRef oak As Tree)



        'pine trees can only be cut down between the ages of 25 and 70 years 
        'oak trees can only be harvested between the ages of 90 and 150 years

        For i = 1 To 25

            'Sub Cut
            'Sub plantOp
            'Sub Age

        Next

    End Sub

    Sub Cut()



    End Sub

    Sub plantOp()



    End Sub

    Sub Age()



    End Sub

End Module
