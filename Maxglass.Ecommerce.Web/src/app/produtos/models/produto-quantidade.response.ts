export class ProdutoQuantidadeResponse {
    quantidade: number;


    constructor(params: Partial<ProdutoQuantidadeResponse>) {
        this.quantidade = params.quantidade || null;
    }

}
