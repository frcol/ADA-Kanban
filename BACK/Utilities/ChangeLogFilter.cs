using Microsoft.AspNetCore.Mvc.Filters;
using QuadroKanban.Data;
using QuadroKanban.Model;

public class ChangeLogFilter : IActionFilter
{
    private CardContext _contextCard;
    private int _id;
    private Card? _card;

    public ChangeLogFilter(CardContext contextCard)
    {
        _contextCard = contextCard;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Request.Method == "PUT" || context.HttpContext.Request.Method == "DELETE")
        {
            _id = Convert.ToInt16(context.RouteData.Values["id"]);
            _card = _contextCard.Cards?.FirstOrDefault(card => card.Id == _id);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request.Method == "PUT" || context.HttpContext.Request.Method == "DELETE")
        {
            // Obtém o horário atual formatado
            string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            if (_card is null) { return; }

            string operacao = context.HttpContext.Request.Method == "PUT" ? "Alterar" : "Remover";

            // Monta a linha de log
            string logLine = $" {formattedDateTime} - Card {_card.Id} - {_card.Titulo} - {operacao}";

            // Escreve no console
            Console.WriteLine(logLine);
        }
    }
}
