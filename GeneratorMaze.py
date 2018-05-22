from random import shuffle, randrange
 
def make_maze(w = 2, h = 2):
    vis = [[0] * w + [1] for _ in range(h)] + [[1] * (w + 1)]
    ver = [["|  "] * w + ['|'] for _ in range(h)] + [[]]
    hor = [["+--"] * w + ['+'] for _ in range(h + 1)]
 
    def walk(x, y):
        vis[y][x] = 1
 
        d = [(x - 1, y), (x, y + 1), (x + 1, y), (x, y - 1)]
        shuffle(d)
        for (xx, yy) in d:
            if vis[yy][xx]: continue
            if xx == x: hor[max(y, yy)][x] = "+  "
            if yy == y: ver[y][max(x, xx)] = "   "
            walk(xx, yy)
 
    walk(randrange(w), randrange(h))
 
    s = ""
    for (a, b) in zip(hor, ver):
        s += ''.join(a + ['\n'] + b + ['\n'])
    return s
 
if __name__ == '__main__':
    s = make_maze(20,20)
    print(s)
    s = s.split('\n')
    matrix_maze = []
    for row in s[:-2]:
        temp = []
        flag = False
        for wall in row:
            if((wall == '+') or (wall=='-')):
                temp.append(1)
            elif(wall == '|'):
                flag=True
                temp.append(1)
            else:
                temp.append(0)

        if(flag):
            matrix_maze.append(temp)
            matrix_maze.append(temp)
        else:
            matrix_maze.append(temp)        

    #
    for row in matrix_maze:
        print(row)
                
        
    
