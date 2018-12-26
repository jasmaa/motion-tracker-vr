import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np
import json
import os

rPoints = []
lPoints = []

# read in motion

fname = "out--2018-26-12--10-43-04.json"

with open(os.path.join("../data", fname)) as f:
    data = json.loads(f.read())

    for frame in data['tracking']:
        rPoints.append((
            frame['rPosition']['x'],
            frame['rPosition']['y'],
            frame['rPosition']['z'],
        ))
        lPoints.append((
            frame['lPosition']['x'],
            frame['lPosition']['y'],
            frame['lPosition']['z'],
        ))
        

# plot data
fig = plt.figure()

ax = fig.add_subplot(111, projection='3d')

ax.scatter(
    list(map(lambda x: x[0], rPoints)),
    list(map(lambda x: x[2], rPoints)),
    list(map(lambda x: x[1], rPoints)),
    c='red'
)
ax.scatter(
    list(map(lambda x: x[0], lPoints)),
    list(map(lambda x: x[2], lPoints)),
    list(map(lambda x: x[1], lPoints)),
    c='blue'
)

ax.set_xlabel('X')
ax.set_ylabel('Z')
ax.set_zlabel('Y')

plt.gca().legend(('right', 'left'))

plt.show()

