export class ProdutoListarRequest {
    tipo: number
    nome: string
    categoria: number
    aro: string
    borda: string
    carcaca: string
    lente: string
    friso: number
    posicao: string
    material: string
    materialBorracha: string
    aberturaFriso: number
    moldura: string
    furoEscapamento: number
    aberturaSpoiler: number
    capa: string
    piscaAlerta: number
    sensorPontoCego: number
    faixa: string
    marca: number

    constructor(params: Partial<ProdutoListarRequest>) {
        this.tipo = params.tipo || null;
        this.nome = params.nome || null;
        this.categoria = params.categoria || null;
        this.aro = params.aro || null;
        this.borda = params.borda || null;
        this.carcaca = params.carcaca || null;
        this.lente = params.lente || null;
        this.friso = params.friso || null;
        this.posicao = params.posicao || null;
        this.material = params.material || null;
        this.materialBorracha = params.materialBorracha || null;
        this.aberturaFriso = params.aberturaFriso || null;
        this.moldura = params.moldura || null;
        this.furoEscapamento = params.furoEscapamento || null;
        this.aberturaSpoiler = params.aberturaSpoiler || null;
        this.capa = params.capa || null;
        this.piscaAlerta = params.piscaAlerta || null;
        this.sensorPontoCego = params.sensorPontoCego || null;
        this.faixa = params.faixa || null;
        this.marca = params.marca || null;

    }
}
