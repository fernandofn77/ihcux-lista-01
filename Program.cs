/*
 Heurísticas aplicadas:

 #1 - Visibilidade do Status:
 Exibição de mensagens indicando o progresso do pedido:
 [Passo 1 de 3], [Passo 2 de 3], etc.

 #3 - Controle e Liberdade:
 O usuário pode digitar "voltar" para retornar à etapa anterior
 ou "cancelar" para encerrar o pedido a qualquer momento.

 #9 - Ajuda e Diagnóstico de Erros:
 Mensagens claras e específicas para erros, como código inválido
 ou entrada não numérica.
*/

using System;

class Program
{
    static void Main()
    {
        int codigo = 0;
        int quantidade = 0;

        while (true) // fluxo geral do sistema
        {
            // ---------------------------
            // PASSO 1 - Código do Produto
            // ---------------------------
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 1 de 3] - Seleção do Produto");
                Console.Write("Digite o código do produto (1 a 10): ");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (int.TryParse(entrada, out codigo))
                {
                    if (codigo >= 1 && codigo <= 10)
                        break;
                    else
                        Console.WriteLine($"Código {codigo} não encontrado. Nossos códigos vão de 1 a 10.");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                }

                Console.WriteLine("Pressione ENTER para tentar novamente...");
                Console.ReadLine();
            }

            // ---------------------------
            // PASSO 2 - Quantidade
            // ---------------------------
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 2 de 3] - Quantidade");
                Console.Write("Digite a quantidade: ");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (entrada == "voltar")
                {
                    break; // volta para passo 1
                }

                if (int.TryParse(entrada, out quantidade))
                {
                    if (quantidade > 0)
                        break;
                    else
                        Console.WriteLine("A quantidade deve ser maior que zero.");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                }

                Console.WriteLine("Pressione ENTER para tentar novamente...");
                Console.ReadLine();
            }

            if (quantidade == 0) continue; // voltou para passo 1

            // ---------------------------
            // PASSO 3 - Confirmação
            // ---------------------------
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 3 de 3] - Confirmação");
                Console.WriteLine($"Produto: {codigo}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.Write("Confirmar pedido? (sim / voltar / cancelar): ");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (entrada == "voltar")
                {
                    quantidade = 0; // força voltar para passo 2
                    break;
                }

                if (entrada == "sim")
                {
                    Console.WriteLine("Pedido realizado com sucesso!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Opção inválida.");
                Console.WriteLine("Pressione ENTER para tentar novamente...");
                Console.ReadLine();
            }
        }
    }
}