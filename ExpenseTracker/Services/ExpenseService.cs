using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly List<Expense> _expenses = new List<Expense>
        {
            new Expense
            {
                ExpenseId = Guid.NewGuid(),
                Title = "Groceries",
                Note = "Weekly grocery shopping",
                Amount = 150.00m,
                Date = DateTime.Now.AddDays(-7),
                Category = ExpenseCategory.Food,
                PaymentMethod = PaymentMethod.CreditCard
            },
            new Expense
            {
                ExpenseId = Guid.NewGuid(),
                Title = "Transport",
                Note = "Monthly bus pass",
                Amount = 50.00m,
                Date = DateTime.Now.AddDays(-30),
                Category = ExpenseCategory.Transport,
                PaymentMethod = PaymentMethod.Cash
            },
            new Expense
            {
                ExpenseId = Guid.NewGuid(),
                Title = "Movie Night",
                Note = "Tickets and snacks",
                Amount = 30.00m,
                Date = DateTime.Now.AddDays(-14),
                Category = ExpenseCategory.Entertainment,
                PaymentMethod = PaymentMethod.DebitCard
            }
        };

        // Add a new expense
        public Task AddExpenseAsync(Expense expense)
        {
            expense.ExpenseId = Guid.NewGuid();
            _expenses.Add(expense);
            return Task.CompletedTask;
        }

        // Delete an expense by ID
        public Task DeleteExpenseAsync(Guid id)
        {
            var expense = _expenses.FirstOrDefault(e => e.ExpenseId == id);
            if (expense != null)
                _expenses.Remove(expense);

            return Task.CompletedTask;
        }

        // Edit/Update an expense
        public Task EditExpenseAsync(Expense updatedExpense)
        {
            var expense = _expenses.FirstOrDefault(e => e.ExpenseId == updatedExpense.ExpenseId);
            if (expense != null)
            {
                expense.Title = updatedExpense.Title;
                expense.Note = updatedExpense.Note;
                expense.Amount = updatedExpense.Amount;
                expense.Date = updatedExpense.Date;
                expense.Category = updatedExpense.Category;
                expense.PaymentMethod = updatedExpense.PaymentMethod;
            }
            return Task.CompletedTask;
        }

        // Get all expenses
        public Task<List<Expense>> GetAllExpensesAsync()
        {
            return Task.FromResult(_expenses.ToList());
        }
        // Get an expense by ID
        public Task<Expense> GetExpenseByIdAsync(Guid id)
        {
            var expense = _expenses.FirstOrDefault(e => e.ExpenseId == id);
            return Task.FromResult(expense);
        }

        // Get total amount of all expenses
        public Task<decimal> GetTotalAmountAsync()
        {
            decimal total = _expenses.Sum(e => e.Amount);
            return Task.FromResult(total);
        }
    }
}
