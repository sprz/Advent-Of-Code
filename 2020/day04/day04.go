package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
	"strconv"
    "regexp"
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

func part2()  {var valid = 0
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

				if strings.HasPrefix(part, "byr") {
					i, err := strconv.Atoi(strings.Split(part,":")[1])
					if err != nil {
						hasByr = false
					} else if i >=1920 && i<=2002 {
						hasByr = true
					}
				}
				
				if strings.HasPrefix(part, "iyr") {
					i, err := strconv.Atoi(strings.Split(part,":")[1])
					if err != nil {
						hasIyr = false
					} else if i >=2010 && i<=2020 {
						hasIyr = true
					}
				}
				
				if strings.HasPrefix(part, "eyr") {
					i, err := strconv.Atoi(strings.Split(part,":")[1])
					if err != nil {
					} else if i >=2020 && i<=2030 {
						hasEyr = true
					}
				}
				
				if strings.HasPrefix(part, "hgt") {

					var splitted = strings.Split(part,":")[1]

					if strings.HasSuffix(splitted, "cm" ) {
						var cms = splitted[0:3]
						i, err := strconv.Atoi(cms)
						if err != nil {
							hasHgt = false
						} else if i >=150 && i<=193 {
							hasHgt = true
						}

					} else if strings.HasSuffix(part, "in" ) {
						var inches = splitted[0:2]
						
						i, err := strconv.Atoi(inches)
						if err != nil {
							hasHgt = false
						} else if i >=59 && i<=76 {
							hasHgt = true
						}
					}
				}
				
				if strings.HasPrefix(part, "hcl") {

					var splitted = strings.Split(part,":")[1]
					
					if string(splitted[0]) != "#" || len(splitted) != 7 {
						hasHcl = false
					} else {
						var color = splitted[1:7]
						match, _ := regexp.MatchString("[0-9a-f]{6}", color)
						hasHcl = match
					}
					
				}
				
				if strings.HasPrefix(part, "ecl") {
					var value = strings.Split(part,":")[1]
					hasEcl = Contains(value)
				}

				if strings.HasPrefix(part, "pid") {
					var value = strings.Split(part,":")[1]
					if len(value) != 9 {
						hasPid = false
					} else{
						_, err := strconv.Atoi(value)
						if err != nil {
							hasPid = false
						} else {
							hasPid = true
						}
					}
					
				}
				

			}
		} else {
			
			// fmt.Println(hasByr,hasIyr,hasEyr,hasHgt,hasHcl,hasEcl,hasPid)

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
	

    fmt.Println("part2: ",valid);
}

func Contains(x string) bool {
	var list =[]string{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}
	for _, item := range list {
		if item == x {
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