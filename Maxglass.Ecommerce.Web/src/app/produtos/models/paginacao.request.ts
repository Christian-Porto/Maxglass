export class PaginacaoRequest {
    quantidadeProdutosPorPagina: number;
    pagina: number;
    totalPaginas: number;
    totalRegistros: number;

    constructor(params: Partial<PaginacaoRequest>) {
        this.quantidadeProdutosPorPagina = params.quantidadeProdutosPorPagina || 3;
        this.pagina = params.pagina || 1;
        this.totalPaginas = params.totalPaginas || null;
        this.totalRegistros = params.totalRegistros || null;

    }
}
