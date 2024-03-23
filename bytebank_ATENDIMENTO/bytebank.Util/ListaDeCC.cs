using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeCC
{
    private ContaCorrente[] _itens = null;
    private int ProximaPosicao = 0;
    public ListaDeCC(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {ProximaPosicao}");
        VerificarCapacidade(ProximaPosicao + 1);
        _itens[ProximaPosicao] = item;
        ProximaPosicao++;
    }

    private void VerificarCapacidade(int TamanhoNecessario)
    {
        if (_itens.Length >= TamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("\nCapacidade da Lista aumentada!");
        ContaCorrente[] novoArray = new ContaCorrente[TamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }

    public void VerificaMaiorSaldo()
    {
        ContaCorrente? contaComMaiorSaldo = _itens[0];
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i].Saldo > contaComMaiorSaldo?.Saldo)
            {
                contaComMaiorSaldo = _itens[i];
            }
        }
        Console.WriteLine($"A conta com maior saldo é de R${contaComMaiorSaldo?.Saldo}");
    }

    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < ProximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }
        for (int i = indiceItem; i < ProximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        ProximaPosicao--;
        _itens[ProximaPosicao] = null;
    }

    public void ExibirLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                var conta = _itens[i];
                Console.WriteLine($" Indice[{i}] = Conta:{conta.Conta} - N° da Agência: {conta.Numero_agencia}" );
            }
        }
    }

    public ContaCorrente RecuperarItemIndice(int indice)
    {
        if (indice < 0||indice >=ProximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }

    public int Tamanho {
        get
        {
            return ProximaPosicao;
        }
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarItemIndice(indice);
        }
    }
}