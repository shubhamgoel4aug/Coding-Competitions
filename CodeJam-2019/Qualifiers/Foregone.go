// This file contains the solution of CodeJam 2019 Qualifiers Problem - Foregone

package main

import (
	"fmt"
	"regexp"
	"strings"
)

func main() {
	var totalcases int
	fmt.Scan(&totalcases)
	for i := 1; i <= totalcases; i++ {
		var input string
		fmt.Scan(&input)
		outNum := strings.Replace(input, "4", "2", -1)
		regReplaceToZero := regexp.MustCompile("[123567890]")
		regTrimLeadingZeros := regexp.MustCompile("^0+")
		fmt.Printf("Case #%d: %s %s\n", i, outNum, strings.Replace(regTrimLeadingZeros.ReplaceAllString(regReplaceToZero.ReplaceAllString(input, "0"), ""), "4", "2", -1))
	}
}
