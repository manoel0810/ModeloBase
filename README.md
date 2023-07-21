# AutoSchematic


### O AutoSchematic é uma extensão de aplicativo DLL escrita em C# .NET Framework 4.8 que auxilia na representação gráfica de bobinas para motores elétricos, bem como o seu fechamento interno das fases. Incluindo suporte para customizações, adaptações e flexibilidade de parâmetros para desempenho, pode ser aplicado em diversos cenários distintos.

# Telas do componente

* Plano inicial para trabalho
  
![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/mainControl.png)

> Este é o seu ambiente de trabalho. Aqui, informações como o número de bobibas, ligações, legendas, etc, são definidos e controlados.

* Ponto-linha livre
  
![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/mainControlFreeVerticeConnect.png)

> Segurando a tecla Ctrl, o usuário pode gerar uma linha a partir de qualquer um dos vértices válidos para outra área do plano. Essa função é útil para representar fios soltos no fechamento interno das bobinas. As linhas verdes são guias para horientação.

* Exemplo de fechamento
  
![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/mainControlLoaded.png)

> A imagem mostra um exemplo prático do uso  da DLL. Logo no canto superior direito, temos as legendas das linhas destacadas pelo usuário. Na borda inferior direita, temos o carimbo com informações importantes sobre o modelo. Tanto as linhas, como pontos, carimbo, legenda e plano possuem suas propriedades.

* Propriedades do plano
  
![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/painel1.png)

> Com essa opções, podemos personalizar o visual do componente, assim como a imagem final que pode ser exportada e salva.

* Ainda no plano, temos as configurações de renderização

![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/painel2.png)

> Com essas propriedades, podemos ajustar o desempenho, quando necessário.

* As linhas também possuem suas propriedades

![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/props2.png)

> Aqui, podemos alterar as propriedades de uma linha específica

* Também as Bobinas!

![Image](https://raw.githubusercontent.com/manoel0810/ModeloBase/master/props1.png)

> Aqui, podemos alterar as propriedades de uma bobina específica


# Configurações
### As configurações são:

| Propriedade                       | Tipo       | Valor Padrão            | Descrição                                            |
|-----------------------------------|------------|------------------------|------------------------------------------------------|
| ESPACAMENTO_LIVRE                 | double     | 7.0                    | Espaçamento livre entre elementos                  |
| FATOR_CORRECAO_BAIXO               | double     | 10.0                   | Fator de correção para valores baixos               |
| FATOR_CORRECAO_ALTO                | double     | 0.0                    | Fator de correção para valores altos                |
| FATOR_CORRECAO_RAIO_MAIOR          | double     | 0.10                   | Fator de correção para raio maior                   |
| FATOR_CORRECAO_RAIO_MENOR          | double     | 0.08                   | Fator de correção para raio menor                   |
| CARIMBO_WIDTH                     | int        | 180                    | Largura do carimbo                                   |
| CARIMBO_HEIGHT                    | int        | 90                     | Altura do carimbo                                    |
| FATOR_CORRECAO_DECREMENTO          | int        | 4                      | Fator de correção para decremento                   |
| FATOR_CORRECAO_LIMITACAO           | int        | 8                      | Fator de correção para limitação                    |
| POINT_SIZE                        | int        | 10                     | Tamanho do ponto                                     |
| POINT_MARGIN                      | int        | 1                      | Margem do ponto                                      |
| RENDER_POINTS                     | int        | 32                     | Pontos de renderização                               |
| SMOOTH_ITERATIONS                 | int        | 1                      | Iterações suaves                                     |
| Y_LEGEND_START                    | int        | 20                     | Início da legenda no eixo Y                          |
| X_LEGEND_START                    | int        | 20                     | Início da legenda no eixo X                          |
| Y_LEGEND_ITERATOR                 | int        | 15                     | Iteração da legenda no eixo Y                        |
| Y_LEGEND_SUB_ITERATOR             | int        | 5                      | Iteração secundária da legenda no eixo Y             |
| LEGEND_LINE_SIZE                  | int        | 80                     | Tamanho da linha da legenda                          |
| LEGEND_LINE_HEIGHT                | float      | 8.0                    | Altura da linha da legenda                           |
| LINE_WIDTH                        | float      | 2.0                    | Largura da linha                                     |
| USE_SMOOTH                        | bool       | true                   | Usar suavização                                      |
| DRAW_LATTERS                      | bool       | true                   | Desenhar letras                                      |
| CARIMBO                           | bool       | true                   | Usar carimbo                                         |
| LEGEND_LINE                       | bool       | true                   | Usar linha de legenda                                |
| TRIFASIC                          | bool       | true                   | Modo trifásico                                       |
| INFO                              | string     | "ESQUEMA MOTOR ELÉTRICO" | Informações adicionais                              |
| MODEL                             | string     | "MODELO"               | Modelo específico                                    |
| CARIMBO_FONT                      | Font       | Consolas, 8pt, Bold    | Fonte do carimbo                                     |
| DateFormat                        | DateFormt  | Long                   | Formato de data                                      |
| BACKGROUND_COLOR_PLANE            | Color      | AliceBlue              | Cor de fundo do plano                               |
| BACKGROUND_COLOR_CARIMBO          | Color      | Yellow                 | Cor de fundo do carimbo                             |
| EIXO_X_COLOR                      | Color      | Blue                   | Cor do eixo X                                       |
| EIXO_Y_COLOR                      | Color      | Red                    | Cor do eixo Y                                       |


## Licença

Este projeto está licenciado sob a [Licença MIT](https://github.com/manoel0810/ModeloBase/blob/master/LICENSE). Você é livre para usar, modificar e distribuir o código-fonte do AutoSchematic de acordo com os termos da licença.

## Aviso Legal

O AutoSchematic é um projeto em desenvolvimento e não oferece garantia de qualquer tipo. O uso deste software é de responsabilidade do usuário. A equipe do EasyLi não se responsabiliza por quaisquer danos ou perdas decorrentes do uso deste software.


## Contato

Se você tiver alguma dúvida, sugestão ou problema relacionado ao AutoSchematic, entre em contato conosco através do email [manoelvictorzxc17@hotmail.com](mailto:manoelvictorzxc17@hotmail.com) ou abra uma issue neste repositório.
