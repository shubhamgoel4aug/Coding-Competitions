// This file contains the solution of CodeJam 2019 Qualifiers Problem - Pylons

package main

import (
	"fmt"
	"strconv"
)

func getNearestCell(grid [][]int, r int, c int, rows int, cols int) (int, int) {
	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			if i != r && j != c && (i-j) != (r-c) && (i+j) != (r+c) && grid[i][j] != 0 {
				return i, j
			}
		}
	}
	return -1, -1
}

func main() {
	var totalcases int
	fmt.Scan(&totalcases)
	for i := 1; i <= totalcases; i++ {
		var placement string
		var rows int
		var cols int
		fmt.Scan(&rows)
		fmt.Scan(&cols)
		var grid [][]int
		for j := 0; j < rows; j++ {
			var tempRow []int
			for k := 0; k < cols; k++ {
				tempRow = append(tempRow, 0)
			}
			grid = append(grid, tempRow)
		}
		placement = "0 0"
		for j := 0; j < rows; j++ {
			for k := 0; k < cols; k++ {
				var r int
				var c int
				if i == 0 && j == 0 {
					grid[0][0] = 1
					r = 0
					c = 0
					a, b := getNearestCell(grid, r, c, rows, cols)
					if a == -1 && b == -1 {
						fmt.Printf("IMPOSSIBLE")
					} else {
						grid[a][b] = 1
						placement += strconv.Itoa(a) + " " + strconv.Itoa(b)
					}
				} else {
					a, b := getNearestCell(grid, r, c, rows, cols)
					if a == -1 && b == -1 {
						fmt.Printf("IMPOSSIBLE")
					} else {
						grid[a][b] = 1
						placement += strconv.Itoa(a) + " " + strconv.Itoa(b)
					}
				}
			}
		}
		fmt.Print(grid)
		fmt.Printf("Case #%d: %d\n", i, cols)
	}
}
