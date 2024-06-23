function countZeroDigit(a,b){
    var i = a
    var sum = 0
    for(i ; i <= b ; i++) {
        sum += i.toString().split('').filter(res => {
            if(res == 0) return res
        }).length
    }
    return sum
}

console.log(countZeroDigit(1, 10))

