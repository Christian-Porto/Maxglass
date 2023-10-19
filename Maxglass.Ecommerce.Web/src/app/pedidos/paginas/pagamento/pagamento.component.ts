import { PedidoService } from './../../services/pedido.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PagamentoService } from './../../services/pagamento.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { PagamentoInserirRequest } from '../../models/pagamento-request';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.css']
})
export class PagamentoComponent implements OnInit {

  pagamentoForm: FormGroup;

  tipoPagamento: number = 1;

  conteudoCopiar = '00020126360014br.gov.bcb.pix0114+55279963748665204000053039865802BR5925Livia Costalonga De Jesus6009Sao Paulo62070503***6304A14A';

  meses = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'];

   anoAtual: number = new Date().getFullYear();
   anosExpiracao: any = Array.from(new Array(15), (x,i) => (this.anoAtual + i).toString());

   valor: number;

   id: number;

  constructor(
    private pagamentoService: PagamentoService,
    private pedidoService: PedidoService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.id = parseInt(this.activatedRoute.snapshot.params['id']);

    this.recuperarValorPedido(this.id);

    this.pagamentoForm = this.formBuilder.
    group({
      numeroCartao: ['',[Validators.required,  Validators.pattern(/^\d{13,16}$/)]],
      mesExpiracao: ['mes',[Validators.required]],
      anoExpiracao: ['anosExpiracao', [Validators.required]],
      nomeImpresso: ['',[Validators.required]],
      codigoSeguranca: ['', [Validators.required, Validators.pattern(/^\d{3}$/)]],
      parcelas: ['1', [Validators.required]]
    });
  }

  copiar(): void {
    // Seleciona o campo
    const campo: HTMLInputElement = document.getElementById('campo-copiar') as HTMLInputElement;
    campo.select();

    // Copia o conteúdo do campo
    document.execCommand('copy');
  }

  recuperarValorPedido(id: number){
    this.pedidoService.recuperarValorPedido(id).subscribe(response => {
      this.valor = response.valor + response.frete.valor;
    });
  }

  pagar(){
    let pagamentos;
    if(this.tipoPagamento == 0){
       pagamentos = {
        tipo: this.tipoPagamento,
        valorParcela : this.valor,
        parcela: 1
      };

    }else if (this.tipoPagamento == 1){
     pagamentos = {
        tipo: this.tipoPagamento,
        valorParcela : (this.valor /  this.pagamentoForm.get('parcelas').value),
        parcela: parseInt(this.pagamentoForm.get('parcelas').value)
      };
    }
    let listaPagamentos = [];
    listaPagamentos.push(pagamentos);

    let pagamentorequest = new PagamentoInserirRequest({valor : this.valor, pagamentos: listaPagamentos, idPedido: this.id });
    this.pagamentoService.pagarPedido(pagamentorequest).subscribe((response)=>{
    });
  }

  alteraTipoPagamento(tipo: number){
    this.tipoPagamento = tipo;
  }
}
