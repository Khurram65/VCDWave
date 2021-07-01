Split(['#left', '#right'], {
    sizes: [25, 75],
    gutterSize: 8,
    minSize: 23,
    direction: 'horizontal'
});

Split(['#lmiddle', '#mmiddle'], {
    sizes: [20, 80],
    minSize: 5,
    gutterSize: 8,
    direction: 'horizontal'
});

Split(['#rtop', '#rbot'], {
    sizes: [50, 50],
    direction: 'vertical',
    gutterSize: 8
});