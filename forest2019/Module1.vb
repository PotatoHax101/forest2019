Imports System.IO

Structure Tree

    Public _age, _ratio As Integer
    Public _disease, _mapleSyrup, _onFire As Boolean
    Public _treeType As String
    Public _isInfected As Boolean

End Structure

Structure Spread

    Public _spread, _infectionChance As Integer 'How many times a year it spreads, the chance of infection (1 - 10)
    Public _name As String

End Structure

Module Module1

    Sub Main()

        Dim forest(100, 100) As Tree 'Dimensions: 0, 1
        Dim pine As Tree
        Dim oak As Tree

        treeDistribution(pine, oak, forest)

        management(pine, oak, forest)

        Console.Read()

    End Sub

    Function treeDistribution(ByRef pine As Tree, ByRef oak As Tree, ByRef forest(,) As Tree)

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

                'Console.WriteLine(forest(i - 1, q - 1)._age)

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

    Sub management(ByRef pine As Tree, ByRef oak As Tree, ByRef forest(,) As Tree)

        Dim numberOfBuckets As Integer

        Dim disease As Spread
        disease._spread = 3
        disease._infectionChance = 3
        disease._name = "disease"

        'pine trees can only be cut down between the ages of 25 and 70 years 
        'oak trees can only be harvested between the ages of 90 and 150 years

        display(forest)

        For i = 0 To 25

            Cut(forest)
            numberOfBuckets = mapleCollection(forest)
            Age(forest)

            'Console.WriteLine("Number of buckets needed: " & numberOfBuckets)

        Next

    End Sub

    Sub display(ByVal forest(,) As Tree)

        Dim forestUpper As Integer = forest.GetUpperBound(0) - 1 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) - 1 'Getting second dimension of 2D array

        For i = 0 To forestUpper

            For q = 0 To forestLower

                Console.Write(treeDraw(forest(i, q)))
                Console.Write(" ")

            Next

        Next

    End Sub

    Function treeDraw(ByVal currentTree As Tree)

        Dim content As String = "", output As String = ""
        Dim treeType = currentTree._treeType

        Using textReader As StreamReader = New StreamReader(treeType & ".txt")

            While Not textReader.EndOfStream

                content = textReader.ReadLine()
                output += vbCrLf + content

            End While

        End Using

        Return output

    End Function

    Sub Cut(ByRef forest(,) As Tree)

        Dim forestUpper As Integer = forest.GetUpperBound(0) - 1 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) - 1 'Getting second dimension of 2D array
        Dim treePlantCount As Integer

        For i = 0 To forestUpper

            treePlantCount = 1

            For q = 0 To forestLower

                If (forest(i, q)._age > 25) And (forest(i, q)._age < 70) And (forest(i, q)._treeType = "pine") Then

                    'Console.WriteLine("Tree " & (i * q) & " has been cut")
                    'Console.WriteLine("Tree Type: " & forest(i, q)._treeType)

                    treePlantCount += 1
                    forest(i, q)._age = 0
                    forest(i, q)._treeType = isMaple(treePlantCount, forest(i, q))

                ElseIf (forest(i, q)._age > 90) And (forest(i, q)._age < 150) And (forest(i, q)._treeType = "oak") Then

                    'Console.WriteLine("Tree " & (i * q) & " has been cut")
                    'Console.WriteLine("Tree Type: " & forest(i, q)._treeType)

                    treePlantCount += 1
                    forest(i, q)._age = 0
                    forest(i, q)._treeType = isMaple(treePlantCount, forest(i, q))


                End If

            Next

        Next

    End Sub

    Function isMaple(ByVal treePlantCount As Integer, ByRef chosenTree As Tree)

        If treePlantCount Mod 3 = 0 Then

            chosenTree._treeType = "maple"

        End If

        Return chosenTree._treeType

    End Function

    Sub Age(ByRef forest(,) As Tree)

        Dim forestUpper As Integer = forest.GetUpperBound(0) - 1 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) - 1 'Getting second dimension of 2D array

        For i = 0 To forestUpper

            For q = 0 To forestLower

                forest(i, q)._age += 1

            Next

        Next

        'Console.WriteLine(forest(15, 8)._age)

    End Sub

    Function mapleCollection(ByRef forest(,) As Tree)

        Dim forestUpper As Integer = forest.GetUpperBound(0) - 1 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) - 1 'Getting second dimension of 2D array

        Dim syrupAmount As Double

        For i = 0 To forestUpper

            For q = 0 To forestLower

                If forest(i, q)._treeType = "maple" And forest(i, q)._age >= 4 Then

                    syrupAmount += 1.5

                End If

            Next

        Next

        Return syrupAmount / 0.5

    End Function

    Sub diseaseSpread(ByRef forest(,) As Tree, ByVal disease As Spread)

        Dim forestUpper As Integer = forest.GetUpperBound(0) - 1 'Getting first dimension of 2D array
        Dim forestLower As Integer = forest.GetUpperBound(1) - 1 'Getting second dimension of 2D array

        Dim luckyDip As New Random()

        For i = 0 To forestUpper - 1

            For q = 0 To forestLower - 1

                If RandomNumberGeneration(1, 100) = 55 Then

                    forest(i, q)._isInfected = True

                End If

            Next

        Next

        'For i = 1 To disease._spread



        'Next

    End Sub

    Function RandomNumberGeneration(ByVal firstIndex As Integer, ByVal lastIndex As Integer)

        Dim rnd As New Random()

        Dim rndNumb As Integer

        Return rndNumb = rnd.Next(firstIndex, lastIndex + 1)

    End Function

End Module
