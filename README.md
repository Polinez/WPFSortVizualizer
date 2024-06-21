# Sorting Algorithms Visualization

## Project Description
The "WPFSortVizualizer" project is a desktop application written in C# using the .NET platform, which allows visualizing various sorting algorithms on sets of numbers.

## User Instructions
After launching the application, enter the numbers to be sorted into the text box or select a random number using the slider. 

![1](https://github.com/Polinez/WPFSortVizualizer/assets/44930743/0d252769-54d6-474a-b011-d2f01a58b201)

Then, choose one of the available sorting algorithms from the dropdown list and click the "Sort" or "Start" button to begin the sorting visualization. You can also pause or resume the visualization by clicking the "Stop" or "Play" button, respectively. To return to the main screen, press the "Return" button.

![2](https://github.com/Polinez/WPFSortVizualizer/assets/44930743/42fa55da-6dde-4aaf-804c-0dd0099b1f93)


## Code Structure
- **MainWindow.xaml**: Contains the user interface for the main application.
- **MainWindow.xaml.cs**: Code-behind file for the main application, handles sorting of numbers.
- **VisualizationWindow.xaml**: Contains the user interface for sorting algorithms visualization.
- **VisualizationWindow.xaml.cs**: Code-behind file for sorting algorithms visualization, manages sorting visualization and animation.
- **Algorithms**: Folder containing implementations of various sorting algorithms.
- **ISortAlgorithm.cs**: Interface for sorting algorithms.

## Code Documentation
- **MainWindow.xaml.cs**: Responsible for user interaction, input retrieval, and invocation of appropriate sorting algorithms.
- **VisualizationWindow.xaml.cs**: Manages sorting algorithms visualization, including animation and view updating.

## Algorithms Description
- **Quick Sort**: Quick sort is a sorting algorithm based on the divide and conquer approach.
- **Bubble Sort**: Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.
- **Insertion Sort**: Insertion sort is a sorting algorithm that builds the final sorted array one element at a time.
- **Selection Sort**: Selection sort is a simple sorting algorithm that repeatedly searches for the minimum (or maximum) element from the unsorted part of the list and moves it to the sorted part.
- **Merge Sort**: Merge sort is a divide and conquer sorting algorithm. It works by recursively dividing the list into smaller parts and then merging them in the proper order.
- **Heap Sort**: Heap sort uses a heap data structure to sort elements.

## Note
I am a learning programmer, and this project is my attempt to show others what I have learned on my programming journey.

## License
This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
