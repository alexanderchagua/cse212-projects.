using Microsoft.VisualBasic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan to Implement MultiplesOf:
        // Input3:
        // - number: The number for which multiples will be generated.
        // - length: The number of multiples to generate.
        //
        // Outputs:
        // - An array of type double containing the multiples of the number.
        //   For example, if number = 3 and length = 5, the output will be {3, 6, 9, 12, 15}.
        //
        // Steps:
        // Step 1: Create an array of type double with a size of 'length' to store the multiples.
        // Step 2: Use a for loop to iterate from 0 to length - 1.
        // Step 3: In each iteration of the loop, calculate the corresponding multiple by multiplying 
        //         the 'number' by the (index of the iteration + 1), as multiples start from the number itself.
        // Step 4: Store each multiple in the array.
        // Step 5: After the loop finishes, return the array with the calculated multiples.

        // start here:
         
        // Step 1: Create an array to store the multiples of the number
        double[] multiples = new double[length];
        
        // Step 2: Use a for loop to fill the array with multiples of the number
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the i-th multiple of the number
            multiples[i] = number * (i + 1);  // The first multiple is 'number' * 1, the second is 'number' * 2, etc.
        }
        
        // Step 4: Return the array with the multiples
        return multiples;
    
    }
    
    

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan to Implement the RotateListRight Function
        //
        // Inputs:
        // - data: A list of integers (e.g., <List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9}>).
        // - amount: An integer indicating how many positions the list should be rotated to the right.
        //   The value of amount will be in the range of 1 to data.Count.
        //
        // Outputs:
        // - The modified data list where the elements have been rotated to the right by the given amount.
        //   For example, if the list is <List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9}> and amount is 3,
        //   the list after rotation will be <List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}>.
        //
        // Steps:
        // Step 1: Validate that the list is not empty and that amount is a valid number within the allowed range (between 1 and data.Count).
        //
        // Step 2: Calculate the effective value of amount using amount % data.Count.
        //         Rotating the list by its full length (or multiples of it) would result in no change.
        //         Using amount % data.Count ensures unnecessary rotations are avoided.
        //
        // Step 3: Split the list into two parts:
        //         - The first part contains the last 'amount' elements of the list.
        //         - The second part contains the first 'data.Count - amount' elements.
        //
        // Step 4: Concatenate the two parts in the correct order to achieve the rotation:
        //         - The part with the last 'amount' elements comes first.
        //         - Then, the part with the first 'data.Count - amount' elements.
        //
        // Step 5: Modify the original data list to contain the newly concatenated list.

        //Star here:

         // Step 1: Validate input
        if (data == null || data.Count == 0 || amount <= 0 || amount >= data.Count)
        {
            // If the list is empty or the amount is out of valid range, no rotation is needed
            return;
        }

        // Step 2: Adjust amount to handle cases where amount >= data.Count
        amount = amount % data.Count;  // If amount == data.Count, it will rotate back to the original position
        
        // Step 3: Split the list into two parts
        List<int> lastPart = data.GetRange(data.Count - amount, amount);  // Last 'amount' elements
        List<int> firstPart = data.GetRange(0, data.Count - amount);       // First 'data.Count - amount' elements
        
        // Step 4: Concatenate the two parts (last part first, then first part)
        data.Clear();  // Clear the original list
        data.AddRange(lastPart);  // Add the last part
        data.AddRange(firstPart);  // Add the first part


    }
}
