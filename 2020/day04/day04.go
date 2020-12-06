package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func part1()  {
	var valid = 0
	var file = readFile()

	var hasByr = false;
	var hasIyr = false
	var hasEyr = false
	var hasHgt = false
	var hasHcl = false
	var hasEcl = false
	var hasPid = false

	var currentRow = 0

	for {
		s := strings.Fields(string(file[currentRow]))
		
		if len(s)>0	{
			for _, part := range s {
				hasByr = hasByr || strings.HasPrefix(part, "byr")
				hasIyr = hasIyr || strings.HasPrefix(part, "iyr")
				hasEyr = hasEyr || strings.HasPrefix(part, "eyr")
				hasHgt = hasHgt || strings.HasPrefix(part, "hgt")
				hasHcl = hasHcl || strings.HasPrefix(part, "hcl")
				hasEcl = hasEcl || strings.HasPrefix(part, "ecl")
				hasPid = hasPid || strings.HasPrefix(part, "pid")
			}
		} else {

			if hasByr && hasIyr && hasEyr && hasHgt && hasHcl && hasEcl && hasPid {
				valid +=1
			}

			hasByr = false;
			hasIyr = false
			hasEyr = false
			hasHgt = false
			hasHcl = false
			hasEcl = false
			hasPid = false
		}

		currentRow +=1
		if currentRow >=len(file){
			break
		}
	}
	

    fmt.Println("part1: ",valid);
}

func part2()  {
    fmt.Println("part1: ",2);
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