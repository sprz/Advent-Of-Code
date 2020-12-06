package main

import (
	"bufio"
	"fmt"
	"log"
    "os"
)

func part1()  {
    var counter = 0


	var txtlines = readFile()
	var x=0
	var y=0
	
	for {

		if string(txtlines[y][x]) == "#"{
			counter +=1
		}

		y+=1

		if y >= len(txtlines) {
			break
		}

		x=(x+3)%len(txtlines[y])
	}


    fmt.Println("part1: ",counter);
}

func part2()  {

	var file = readFile()

	var oneOne = countTrees(1,1,file)
	var threeOne = countTrees(3,1,file)
	var fiveOne = countTrees(5,1,file)
	var sevenOne = countTrees(7,1,file)
	var oneTwo = countTrees(1,2,file)

	fmt.Println(oneOne)
	fmt.Println(threeOne)
	fmt.Println(fiveOne)
	fmt.Println(sevenOne)
	fmt.Println(oneTwo)
	

    fmt.Println("part2: ",oneOne*threeOne*fiveOne*sevenOne*oneTwo);
}
func countTrees(xMove int ,yMove int, mapp []string) int {
	var counter = 0
	var x=0
	var y=0
	for {

		if string(mapp[y][x]) == "#"{
			counter +=1
		}

		y+=yMove

		if y >= len(mapp) {
			break
		}

		x=(x+xMove)%len(mapp[y])
	}
	return counter;
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