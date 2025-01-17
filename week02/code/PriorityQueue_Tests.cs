using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue and Dequeue a single item
    // Expected Result: Dequeue should return the only item in the queue
    // Defect(s) Found: None
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Task1", result, "Dequeue should return the single item added.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue should return items in order of their priority (highest first)
    // Defect(s) Found: Priority comparison logic was incorrect
    public void TestPriorityQueue_MultipleItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 3);
        priorityQueue.Enqueue("Task3", 2);

        Assert.AreEqual("Task2", priorityQueue.Dequeue(), "Task with highest priority should be dequeued first.");
        Assert.AreEqual("Task3", priorityQueue.Dequeue(), "Next task with second highest priority should be dequeued.");
        Assert.AreEqual("Task1", priorityQueue.Dequeue(), "Task with lowest priority should be dequeued last.");
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority
    // Expected Result: Items with the same priority should follow FIFO order
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 2);
        priorityQueue.Enqueue("Task2", 2);
        priorityQueue.Enqueue("Task3", 2);

        Assert.AreEqual("Task1", priorityQueue.Dequeue(), "First enqueued item with same priority should be dequeued first.");
        Assert.AreEqual("Task2", priorityQueue.Dequeue(), "Second enqueued item with same priority should be dequeued second.");
        Assert.AreEqual("Task3", priorityQueue.Dequeue(), "Third enqueued item with same priority should be dequeued last.");
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}