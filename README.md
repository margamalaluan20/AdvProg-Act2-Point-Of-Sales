# AdvProg Activity 2 - Point of Sales

A simple desktop Point-of-Sales (POS) application developed in C# using Windows Forms. This project is designed to simulate a retail transaction system where users can add products to a cart, compute totals, apply VAT, enter cash payment, and calculate change.

## Features

- Add product details to the sales list
- Automatically compute total amount due
- Calculate sales VAT and exempted/less VAT values
- Handle cash payment input
- Compute change for customer payment
- Clear the transaction summary
- User-friendly Windows Forms interface

## Tech Stack

- C#
- .NET 10.0 Windows
- Windows Forms (WinForms)

## Project Structure

```text
AdvProg-Act2-Point-Of-Sales/
├── AdvProg-Act2-Point-Of-Sales.slnx
├── AdvProg-Act2-Point-Of-Sales/
│   ├── AdvProg-Act2-Point-Of-Sales.csproj
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── Program.cs
│   └── Properties/
├── .gitignore
├── .gitattributes
└── README.md
```

## Requirements

- Windows operating system
- Visual Studio 2022 or later
- .NET SDK compatible with `net10.0-windows`

## How to Run

1. Clone the repository:

```bash
git clone https://github.com/margamalaluan20/AdvProg-Act2-Point-Of-Sales.git
```

2. Open the solution file:

```text
AdvProg-Act2-Point-Of-Sales.slnx
```

3. Restore NuGet packages if prompted.

4. Build and run the application in Visual Studio.

## Usage

1. Enter the product code, name, price, and quantity.
2. Click the add button to place the item in the sales receipt.
3. The system will update the total amount, VAT, and less-VAT values.
4. Enter the cash rendered by the customer.
5. Click the print/compute action to calculate the change.
6. Use the clear function to reset the transaction.

## Notes

This project is intended for academic and learning purposes as part of an Advanced Programming activity focused on Windows Forms and business transaction logic.

## License

This project does not currently include a specific license file. Please contact me for licensing details if needed.
