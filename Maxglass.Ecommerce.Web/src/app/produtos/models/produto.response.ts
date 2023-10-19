export class ProdutoResponse {
    id: number;
    nome: string;
    valor: number;
    imagens: any;
    marca: any;
    categoria: any;
    chaveEquivalencia: any;

    constructor(params: Partial<ProdutoResponse>) {
        this.id = params.id || null;
        this.nome = params.nome || '';
        this.valor = params.valor || null;
        this.imagens = params.imagens || null;
        this.marca = params.marca || null;
        this.categoria = params.categoria || null;
        this.chaveEquivalencia = params.chaveEquivalencia || null;
    }
}
