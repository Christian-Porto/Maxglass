import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { FreteListarRequest } from 'src/app/pedidos/models/entrega-request';
import { FreteResponse } from 'src/app/pedidos/models/entrega-response';
import { PedidoCadastroRequest } from 'src/app/pedidos/models/pedido-cadastro-request';
import { ItemPedidoRequest } from 'src/app/pedidos/models/pedido-carrinho-request';
import { CarrinhoService } from 'src/app/pedidos/services/carrinho.service';
import { EntregaService } from 'src/app/pedidos/services/entrega.service';
import { PaginacaoResponse } from 'src/app/shared/models/paginacao/response/paginacao.response';

@Component({
  selector: 'app-entrega',
  templateUrl: './entrega.component.html',
  styleUrls: ['./entrega.component.css']
})
export class EntregaComponent implements OnInit {
  cadastroForm: FormGroup;
  regiao: string = "";
  freteListarRequest: FreteListarRequest = new FreteListarRequest({});
  fretes!: PaginacaoResponse<FreteResponse>;
  valores: number;
  frete: number;

  onCEPChange() {
    this.regiao = this.getRegionFromCEP(this.cadastroForm.value.cep);
    this.recuperarArrayRegistros();
  }

  constructor(private formBuilder: FormBuilder,
    private entregaService: EntregaService,
    private carrinhoService: CarrinhoService, 
    private readonly router: Router) { }

  ngOnInit(): void {
    this.cadastroForm = this.formBuilder.group({
      cep: ['', [Validators.required, Validators.pattern(/^[0-9]{8}$/)]],
      checkbox: ['', [Validators.required]],
      endereco: ['', [Validators.required]],
      numero: ['', [Validators.required, Validators.pattern(/^[1-9]*$/)]],
      complemento: ['', [Validators.required]]
    });
  }

  private getRegionFromCEP(cep: string): string {
    // First, remove any non-numeric characters from the CEP  
    cep = cep.replace(/\D/g, "");
    // Next, check the length of the CEP. If it is not 8 characters long, return an empty string  
    if (cep.length !== 8) { return ""; }

    // Validate the first two digits of the CEP
    const firstTwoDigits = cep.substring(0, 2);
    if (firstTwoDigits < '01000000' || firstTwoDigits > '99999999') {
      console.log("Invalid CEP");
      return "";
    }

    // Validate the Sudeste region
    if (cep >= '01000000' && cep <= '39999999') {
      return "Sudeste";
    }

    // Validate the Sul region
    if (cep >= '80000000' && cep <= '99999999') {
      return "Sul";
    }

    // Validate the Nordeste region
    if (cep >= '40000000' && cep <= '65999999') {
      return "Nordeste";
    }

    // Validate the Norte region
    if ((cep >= '66000000' && cep <= '69999999') || (cep >= '76800000' && cep <= '77999999')) {
      return "Norte";
    }

    // Validate the Centro-Oeste region
    if ((cep >= '70000000' && cep <= '76799999') || (cep >= '78000000' && cep <= '79999999')) {
      return "Centro-Oeste";
    }

    // If the CEP does not match any of the above regions, return an empty string
    return "";
  }

  montaQuery(): HttpParams {
    let params = new HttpParams();
    params = params.set('pagina', 1);
    params = params.set('quantidade', 5);
    if (this.freteListarRequest.regiao) {
      params = params.set('regiao', this.freteListarRequest.regiao);
    }
    return params;
  }

  recuperarArrayRegistros() {
    this.entregaService.recuperarArrayRegistros(this.montaQuery()).subscribe(response => {
      this.fretes = response;
      if (this.fretes && this.fretes.registros) {
        this.fretes.registros.forEach(frete => {
          if (frete.regiao === this.getRegionFromCEP(this.cadastroForm.value.cep)) {
            this.valores = frete.valor;
            this.frete = frete.id;
          }
        });
      }
    })
  }

  submit() {
    let itensPedido : ItemPedidoRequest[];
    itensPedido = this.carrinhoService.recuperaItensCarrinho();

    let pedidoCadastroRequest = new PedidoCadastroRequest({
      cep: this.cadastroForm.value.cep,
      complementoEndereco: `${this.cadastroForm.value.endereco} - ${this.cadastroForm.value.complemento}`,
      numeroEndereco: (this.cadastroForm.value.numero).toString(),
      idFrete: this.frete, itemPedidoRequest: itensPedido
    });
    
    this.entregaService.cadastrarEntrega(pedidoCadastroRequest).subscribe((response) => {
      this.router.navigate([`pedidos/pagamento/${response.id}`])
      ;
    });
  }

}
