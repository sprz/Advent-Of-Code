package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func part1()  {
	
	var file = readFile()

	var counter = 0
	var letters = [] rune{}

	for i:=0;i<len(file);i++ {
		
		if len(file[i])>0	{
			for _, letter := range file[i] {
				if contains(letters,letter) == false{
					letters = append(letters,letter)
				}
			}
		} else {
			counter +=len(letters)
			letters = [] rune{}
		}
	}
	counter +=len(letters)

    fmt.Println("part1: ",counter);
}

func part2() {	
	var file = readFile()

	var counter = 0
	 var letters = [] rune{}
	 var filteredLetters = [] rune{}
	var isFirst = true

	for i:=0;i<len(file);i++ {
		
		if len(file[i])>0	{
			for _, letter := range file[i] {
				if isFirst {
					filteredLetters = append(filteredLetters,letter)
				} else if contains(letters,letter){
					filteredLetters = append(filteredLetters,letter)
				}
			}
			letters = filteredLetters
			filteredLetters = [] rune{}
			isFirst = false
		} else {
			counter +=len(letters)
			letters = [] rune{}
			isFirst = true;
		}
	}
	counter +=len(letters)

    fmt.Println("part2: ",counter);
}

func  contains(s []rune,e rune) bool {
    for _, a := range s {
        if a == e {
			// fmt.Println(a)
            return true
        }
    }
    return false
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