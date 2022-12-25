# No. 12, Kürzester Weg in einem Labyrinth

Das schwierigste in einer Problemlösung ist ja i.d.R. ein passendes Konzept/Modell zu finden. Meist entwickeln sich die Assoziationen erst im Laufe der intensiven Beschäftigung.

Intuitiv wählte ich im ersten Schritt die Generierung einer geordnete Menge von verknüpften Positionen, die jeweils einen optionalen Nachbarn haben. Durch die Optionalität werden die verbotenen Richtungen abgebildet. Anschaulich sind es die Wände in einem Labyrinth (maze).

## Rekursiver Ansatz
Als erstes habe ich einen rekursiven Ansatz versucht, einer der die ausgehend von der Startposition erstmal immer links abbiegt und schaut ob das Ziel getroffen wird. Geht es nicht weiter, dann geht der Algo eine Schritt zurück und nimmt die nächste mögliche Position. Ist keine vorhanden, dann gehts wieder einen Schritt zurück. usw.

Das bringt mit den Testdaten 7 mögliche Pfade mit der Länge 31. Diese unterscheiden sich dann partiell in den Anfangsabschnitten.

Für die Puzzle Daten stiegt die Laufzeit dann (schon erwartet) ins Unzumutbare.

Verworfen.

## Breitensuche BFS

Beim Suchen nach alternativen Lösungen kam ich auf BFS Breadth-First-Search, der im Gegensatz zu dem Rekursiven Ansatz versucht, in seiner Betrachtungstiefe des Graphen immer unterhalb der minimalen Pfadlänge zu bleiben, dafür aber alle möglichen Pfade dahin parallel betrachtet.

Dies war dann einfach und brauchte auch in meiner DD orientierten strukturierten Form nur wenig Zeit.

## Anmerkung

Da grad' Weihnachten ist drängten sich mir dann die Frage auf, ob das nicht auch ein Bild für das Verhalten von uns Menschen ist, die alzu gern die Blätter streicheln und sich Details anschauen, in der Hofnung in der Detailversessenheit die grundsätzliche Lösung zu finden?
