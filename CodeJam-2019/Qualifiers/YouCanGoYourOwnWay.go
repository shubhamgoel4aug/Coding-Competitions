// This file contains the solution of CodeJam 2019 Qualifiers Problem - You Can Go Your Own Way

package main

import (
	"fmt"
	"strings"
)

func main() {
	var totalcases int
	fmt.Scan(&totalcases)
	for i := 1; i <= totalcases; i++ {
		var maze int
		var input string
		fmt.Scan(&maze)
		fmt.Scan(&input)
		input = strings.Replace(input, "E", "Z", -1)
		input = strings.Replace(input, "S", "E", -1)
		input = strings.Replace(input, "Z", "S", -1)
		fmt.Printf("Case #%d: %s\n", i, input)
	}
}
