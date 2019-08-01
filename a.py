#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the queensAttack function below.
def queensAttack(n, k, r_q, c_q, obstacles):
    l = []
    for x in range(0,n+1):
        d = []
        for y in range(0,n+1):
            d.append(1)
        l.append(d)
    tmp = r_q
    r_q=c_q
    c_q=tmp

    for x in range(0,k):
        l[obstacles[x][0]-1][obstacles[x][1]-1] =0

    found =0
    #up
    for x in range(r_q-1, 0,  -1):
        if l[c_q    ][x]!=0:
            found = found +1
        else:
            break
        
    #down
    print(found)
    for x in range(r_q-1,n,1):
        if l[c_q][x]!=0:
            found = found+1
        else:
            break;
    #left
    print(found)
    for x in range(c_q-1,0,-1):
        if l[x][r_q]!=0:
            found = found+1
        else:
            break
    #right
    print(found)
    for x in range(c_q+1,n,1):
        if l[x][r_q]!=0:
            found= found+1
        else:
            break;
    #up and left
    print(found)
    j =  r_q-1
    for x in range(c_q-1,0,-1):
        if(j<0):
            break
        if  l[x][j]!=0:
            found+=1
        else:
            break
        j-=1
    #up and right
    print(found)
    j = r_q-1
    for x in range(c_q+1,n,1):
        if j<0:
            break;
        if l[x][j] !=0:
            found+=1
        else:
            break
        j+=1

    #down and left 
    print(found)
    j = r_q+1
    for x in range(c_q-1,0,-1):
        if j >=n:
            break;
        if l[x][j]!=0:
            found+=1
        else:
            break
        j+=1
    #down and right
    print(found)
    j =r_q+1
    for x in range(c_q+1, n,1):
        if j >=n:
            break
        if(board[x][j]!=0):
            found+=1
        else:
            break
        j+=1
    print(found)
    return found


if __name__ == '__main__':
   # fptr = open(os.environ['OUTPUT_PATH'], 'w')

    nk = input().split()

    n = int(nk[0])

    k = int(nk[1])

    r_qC_q = input().split()

    r_q = int(r_qC_q[0])

    c_q = int(r_qC_q[1])

    obstacles = []

    for _ in range(k):
        obstacles.append(list(map(int, input().rstrip().split())))

    result = queensAttack(n, k, r_q, c_q, obstacles)
   # print(result)

   # fptr.write(str(result) + '\n')

   # fptr.close()
