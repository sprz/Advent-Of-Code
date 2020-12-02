package main

import (
	"bufio"
	"fmt"
	"log"
    "os"
    "strings"
    "strconv"
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

   for _, line := range txtlines {
        s := strings.Fields(string(line))
        var splittedRange = strings.Split(s[0],"-")
        min,err := strconv.Atoi(splittedRange[0])
        if err != nil {
            log.Fatalf("failed miun")
        }
        max,err := strconv.Atoi(splittedRange[1])
        if err != nil {
            log.Fatalf("failed max")
        }
        var passwordLetter = string(s[1][0])
        // fmt.Println(passwordLetter)
        // fmt.Println(min)
        // fmt.Println(max)
        var letterCount = 0;
        for _,letter := range s[2]{
            if string(letter) == passwordLetter{
                letterCount++
            }
        }
        if letterCount >= min {
            if letterCount <=max {
                valid++  
            }
        }
    }
    fmt.Println("part1: ",valid);
}

func part2()  {
    var valid = 0

    fmt.Println("part2: ",valid);
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

   for _, line := range txtlines {
        s := strings.Fields(string(line))
        var splittedRange = strings.Split(s[0],"-")
        min,err := strconv.Atoi(splittedRange[0])
        if err != nil {
            log.Fatalf("failed miun")
        }
        max,err := strconv.Atoi(splittedRange[1])
        if err != nil {
            log.Fatalf("failed max")
        }
        var passwordLetter = s[1][0]

        if s[2][min-1] == passwordLetter && s[2][max-1] != passwordLetter{
            valid++
        } else if s[2][min-1] != passwordLetter && s[2][max-1] == passwordLetter {
            valid++  
        }
    }
    fmt.Println("part2: ",valid);
}
func main() {
    part1()
    part2()
}