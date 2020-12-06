package main

import (
	"bufio"
	"fmt"
	"log"
    "os"
)

func part1()  {
    var valid = 0
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

	var x=0
	var y=0
	
	for {

		if string(txtlines[x][y]) == "#"{
			valid +=1
			fmt.Println("X:",x,", Y:",y)
		}

		x+=1

		if x >= len(txtlines) {
			break
		}

		y=(y+3)%len(txtlines[x])
	}


    fmt.Println("part1: ",valid);
}

func part2()  {
    fmt.Println("part2: ",2);
}
func main() {
    part1()
    part2()
}