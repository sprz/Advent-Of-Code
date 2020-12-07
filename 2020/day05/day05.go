package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"math"
)

func part1()  { 
	var file = readFile();
	var maxSeatId = 0;
	var row = 0;
	var col = 0;
	for _, line := range file {
		for i:=0;i<7;i++{
			if string(line[i]) == "B"{
				row += int(math.Pow(2,float64(7-i-1)))
			}
		}

		for i:=0;i<3;i++{
			if string(line[i+7]) == "B"{
				col += int(math.Pow(2,float64(7-i-1)))
			}
		}
		var seatId = row * 8 + col;
		
		if maxSeatId < seatId{
			maxSeatId = seatId;
			println("row:", row, ", col:", col)
		}
		row = 0;
		col = 0;
	}
    fmt.Println("part1: ",maxSeatId);
}

func part2()  {
    fmt.Println("part2: ",2);
}


func readFile() []string{
	file, err := os.Open("data.txt")
	if err != nil {
		log.Fatalf("failed opening file: %s", err)
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var txtlines []string
 
	for scanner.Scan() {
		txtlines = append(txtlines, scanner.Text())
	}
	file.Close()
	return txtlines
}
func main() {
    part1()
    part2()
}