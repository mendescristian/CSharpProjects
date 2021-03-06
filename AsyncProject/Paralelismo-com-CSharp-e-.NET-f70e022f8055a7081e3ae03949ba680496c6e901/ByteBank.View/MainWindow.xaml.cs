using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = true;
            BtnProcessar.IsEnabled = false;
            
            _cts = new CancellationTokenSource();

            try
            {
                var contas = r_Repositorio.GetContaClientes();

                AtualizarView(new List<string>(), TimeSpan.Zero);

                var inicio = DateTime.Now;

                var resultado = await ProcessamentoContasAsync(contas, _cts.Token);

                var fim = DateTime.Now;

                AtualizarView(resultado, fim - inicio);


            }
            catch (TaskCanceledException)
            {
                TxtTempo.Text = "Operação cancelada!";
                
            }

 


            BtnProcessar.IsEnabled = true;
            BtnCancelar.IsEnabled = false;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
            _cts.Cancel();
           
        }

        private async Task<string[]> ProcessamentoContasAsync(IEnumerable<ContaCliente> contas, CancellationToken token)
        {
            var tasks = contas.Select(conta =>
                Task.Factory.StartNew(() => {
                    token.ThrowIfCancellationRequested();
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta, token);
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException(resultadoProcessamento);
                    return resultadoProcessamento;
                }, token)
                
            );

            return await Task.WhenAll(tasks);
            
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
