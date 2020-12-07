package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func part1()  { 
    fmt.Println("part1: ",1);
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