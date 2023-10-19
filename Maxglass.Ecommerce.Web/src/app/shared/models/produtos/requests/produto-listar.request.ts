export class ProdutoListarRequest{

    pagina: number;
    quantidade: number;

    constructor(params: Partial<ProdutoListarRequest>) {
        this.pagina = params.pagina || 1;
        this.quantidade = params.quantidade || 10;
    }
}
