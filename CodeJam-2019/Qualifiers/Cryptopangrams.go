// This file contains the solution of CodeJam 2019 Qualifiers Problem - Cryptopangrams
// Note: This solution is working in my laptop but on Google servers it fails with runtime error. If anyone find out the bug, please do let me know.

package main

import (
	"bufio"
	"fmt"
	"math/big"
	"math/rand"
	"os"
	"strconv"
	"strings"
)

func getcommonfactor(a *big.Int, b *big.Int) *big.Int {
	small := a
	bigval := b
	if a.Cmp(b) == 1 {
		*small = *b
		*bigval = *a
	}
	rem := new(big.Int)
	rem, _ = rem.SetString("1", 10)
	bigzero := new(big.Int)
	bigzero, _ = bigzero.SetString("0", 10)
	bigone := new(big.Int)
	bigone, _ = bigone.SetString("1", 10)
	for rem.Cmp(bigzero) != 0 {
		rem.Mod(bigval, small)
		*bigval = *small
		*small = *rem
		if rem.Cmp(bigzero) != 0 {
			*rem = *bigone
		} else {
			*rem = *bigzero
		}
	}
	return bigval
}

func quicksort(a []*big.Int) []*big.Int {
	if len(a) < 2 {
		return a
	}
	left, right := 0, len(a)-1
	pivot := rand.Int() % len(a)
	a[pivot], a[right] = a[right], a[pivot]
	for i := range a {
		if a[i].Cmp(a[right]) == -1 {
			a[left], a[i] = a[i], a[left]
			left++
		}
	}
	a[left], a[right] = a[right], a[left]
	quicksort(a[:left])
	quicksort(a[left+1:])
	return a
}

func main() {
	reader := bufio.NewReader(os.Stdin)
	cases, _, err := reader.ReadLine()
	icases, _ := strconv.Atoi(string(cases))
	for i := 1; i <= icases; i++ {
		line, _, err := reader.ReadLine()
		if err != nil {
			return
		}
		inputlines, _ := strconv.Atoi(strings.Split(string(line), " ")[1])
		input, _, err := reader.ReadLine()
		if err != nil {
			return
		}
		inputarray := strings.Split(string(input), " ")
		val1 := new(big.Int)
		val1, _ = val1.SetString(inputarray[0], 10)
		val2 := new(big.Int)
		val2, _ = val2.SetString(inputarray[1], 10)
		outputarray := []*big.Int{}
		outputarraytemp := []*big.Int{}
		commonfactor := getcommonfactor(val1, val2)
		inputint := new(big.Int)
		inputint, _ = inputint.SetString(inputarray[0], 10)
		inputintdividecommonfactor := new(big.Int)
		inputintdividecommonfactor.Div(inputint, commonfactor)
		outputarray = append(outputarray, inputintdividecommonfactor)
		outputarraytemp = append(outputarraytemp, inputintdividecommonfactor)
		outputarray = append(outputarray, commonfactor)
		outputarraytemp = append(outputarraytemp, commonfactor)
		for j := 1; j <= inputlines-1; j++ {
			inputint := new(big.Int)
			inputint, _ = inputint.SetString(inputarray[j], 10)
			inputintdivideoutputarray := new(big.Int)
			inputintdivideoutputarray.Div(inputint, outputarray[j])
			outputarray = append(outputarray, inputintdivideoutputarray)
			test := true
			for _, x := range outputarraytemp {
				if outputarray[j+1].Cmp(x) == 0 {
					test = false
					break
				}
			}
			if test {
				outputarraytemp = append(outputarraytemp, inputintdivideoutputarray)
			}
		}
		outputarraytemp = quicksort(outputarraytemp)
		alphabets := [26]string{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
		alphabetmap := make(map[string]string)
		for j, x := range outputarraytemp {
			alphabetmap[x.String()] = alphabets[j]
		}
		fmt.Printf("Case #%d: ", i)
		for _, x := range outputarray {
			fmt.Printf("%s", alphabetmap[x.String()])
		}
		fmt.Printf("\n")
	}
	if err != nil {
		return
	}
}
