---
title: Benchmarks - debian
---

# Benchmarks: debian

**.NET** 10.0.3 &nbsp;&middot;&nbsp; **Commit** `2431f4a` &nbsp;&middot;&nbsp; 9 May 2026 23:07 UTC &nbsp;&middot;&nbsp; 92 benchmarks

## Analysis

| Method             | DocumentCount | Mean    | Error    | StdDev   | Ratio | Gen0        | Gen1      | Allocated | Alloc Ratio |
|------------------- |-------------- |--------:|---------:|---------:|------:|------------:|----------:|----------:|------------:|
| LeanLucene_Analyse | 100000        | 1.535 s | 0.0073 s | 0.0068 s |  1.00 |  49000.0000 | 2000.0000 | 199.73 MB |        1.00 |
| LuceneNet_Analyse  | 100000        | 2.256 s | 0.0029 s | 0.0025 s |  1.47 | 144000.0000 |         - | 576.92 MB |        2.89 |

## analysis-filters

| Method | Scenario             | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| **Apply**  | **decim(...)ating [22]** |  **89.16 ns** | **0.166 ns** | **0.155 ns** | **0.0286** |     **120 B** |
| **Apply**  | **elision-mutating**     | **154.58 ns** | **0.421 ns** | **0.394 ns** | **0.0362** |     **152 B** |
| **Apply**  | **length-mutating**      |  **53.04 ns** | **0.095 ns** | **0.089 ns** | **0.0249** |     **104 B** |
| **Apply**  | **length-noop**          |  **47.66 ns** | **0.094 ns** | **0.084 ns** | **0.0249** |     **104 B** |
| **Apply**  | **reverse-mutating**     |  **70.00 ns** | **0.131 ns** | **0.109 ns** | **0.0381** |     **160 B** |
| **Apply**  | **shingle-mutating**     | **259.53 ns** | **0.776 ns** | **0.726 ns** | **0.1202** |     **504 B** |
| **Apply**  | **truncate-mutating**    |  **57.43 ns** | **0.142 ns** | **0.133 ns** | **0.0306** |     **128 B** |
| **Apply**  | **truncate-noop**        |  **43.20 ns** | **0.102 ns** | **0.090 ns** | **0.0249** |     **104 B** |
| **Apply**  | **unique-mutating**      | **150.77 ns** | **0.358 ns** | **0.318 ns** | **0.0706** |     **296 B** |
| **Apply**  | **word-(...)ating [23]** | **447.43 ns** | **0.885 ns** | **0.828 ns** | **0.2217** |     **928 B** |

## analysis-parity

| Method                | Mean      | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|-------:|----------:|------------:|
| LeanLucene_Whitespace | 39.058 μs | 0.0512 μs | 0.0479 μs |  1.00 |      - |         - |          NA |
| LuceneNet_Whitespace  | 76.250 μs | 0.1543 μs | 0.1443 μs |  1.95 | 0.7324 |    3200 B |          NA |
| LeanLucene_Keyword    |  3.993 μs | 0.0067 μs | 0.0062 μs |  0.10 |      - |         - |          NA |
| LuceneNet_Keyword     | 12.566 μs | 0.0216 μs | 0.0202 μs |  0.32 | 0.7629 |    3200 B |          NA |
| LeanLucene_Simple     | 39.651 μs | 0.0821 μs | 0.0768 μs |  1.02 |      - |         - |          NA |
| LuceneNet_Simple      | 84.560 μs | 0.1543 μs | 0.1368 μs |  2.16 | 0.7324 |    3200 B |          NA |

## Block-Join

| Method                           | BlockCount | Mean          | Error       | StdDev      | Ratio | Gen0      | Gen1     | Allocated  | Alloc Ratio |
|--------------------------------- |----------- |--------------:|------------:|------------:|------:|----------:|---------:|-----------:|------------:|
| LeanLucene_IndexBlocks           | 500        | 82,662.240 μs | 352.5100 μs | 312.4910 μs | 1.000 | 1714.2857 | 857.1429 | 13892496 B |       1.000 |
| LeanLucene_BlockJoinQuery        | 500        |      7.160 μs |   0.0126 μs |   0.0118 μs | 0.000 |    0.1678 |        - |      720 B |       0.000 |
| LuceneNet_IndexBlocks            | 500        | 56,608.486 μs | 398.8941 μs | 353.6092 μs | 0.685 | 5000.0000 | 666.6667 | 28714791 B |       2.067 |
| LuceneNet_ToParentBlockJoinQuery | 500        |     21.839 μs |   0.0514 μs |   0.0456 μs | 0.000 |    3.0518 |        - |    12888 B |       0.001 |

## Boolean queries

| Method                  | BooleanType | DocumentCount | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0     | Gen1    | Allocated | Alloc Ratio |
|------------------------ |------------ |-------------- |---------:|--------:|--------:|------:|--------:|---------:|--------:|----------:|------------:|
| **LeanLucene_BooleanQuery** | **Must**        | **100000**        | **267.3 μs** | **2.53 μs** | **2.11 μs** |  **1.00** |    **0.00** |   **2.9297** |       **-** |  **12.93 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | Must        | 100000        | 484.9 μs | 1.46 μs | 1.29 μs |  1.81 |    0.01 |  35.1563 |       - | 144.09 KB |       11.14 |
|                         |             |               |          |         |         |       |         |          |         |           |             |
| **LeanLucene_BooleanQuery** | **MustNot**     | **100000**        | **173.5 μs** | **1.06 μs** | **0.94 μs** |  **1.00** |    **0.00** |   **3.1738** |       **-** |   **13.3 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | MustNot     | 100000        | 403.6 μs | 7.77 μs | 7.26 μs |  2.33 |    0.04 |  36.1328 |       - | 149.06 KB |       11.21 |
|                         |             |               |          |         |         |       |         |          |         |           |             |
| **LeanLucene_BooleanQuery** | **Should**      | **100000**        | **221.9 μs** | **1.71 μs** | **1.60 μs** |  **1.00** |    **0.00** |   **3.1738** |       **-** |  **13.69 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | Should      | 100000        | 587.2 μs | 1.65 μs | 1.54 μs |  2.65 |    0.02 | 169.9219 | 40.0391 | 695.01 KB |       50.76 |

## Deletion

| Method                     | DocumentCount | Mean     | Error    | StdDev   | Ratio | Gen0        | Gen1       | Gen2      | Allocated | Alloc Ratio |
|--------------------------- |-------------- |---------:|---------:|---------:|------:|------------:|-----------:|----------:|----------:|------------:|
| LeanLucene_DeleteDocuments | 100000        | 10.914 s | 0.0479 s | 0.0448 s |  1.00 | 199000.0000 | 89000.0000 | 9000.0000 |   1.19 GB |        1.00 |
| LuceneNet_DeleteDocuments  | 100000        |  7.203 s | 0.0326 s | 0.0305 s |  0.66 | 339000.0000 | 34000.0000 | 1000.0000 |   1.91 GB |        1.61 |

## Fuzzy queries

| Method                | QueryTerm | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0     | Gen1     | Allocated  | Alloc Ratio |
|---------------------- |---------- |-------------- |---------:|----------:|----------:|------:|---------:|---------:|-----------:|------------:|
| **LeanLucene_FuzzyQuery** | **goverment** | **100000**        | **6.894 ms** | **0.0565 ms** | **0.0501 ms** |  **1.00** |        **-** |        **-** |   **25.88 KB** |        **1.00** |
| LuceneNet_FuzzyQuery  | goverment | 100000        | 8.674 ms | 0.0317 ms | 0.0297 ms |  1.26 | 593.7500 | 203.1250 | 2870.85 KB |      110.93 |
|                       |           |               |          |           |           |       |          |          |            |             |
| **LeanLucene_FuzzyQuery** | **markts**    | **100000**        | **7.525 ms** | **0.0454 ms** | **0.0403 ms** |  **1.00** |   **7.8125** |        **-** |   **47.66 KB** |        **1.00** |
| LuceneNet_FuzzyQuery  | markts    | 100000        | 9.247 ms | 0.0267 ms | 0.0250 ms |  1.23 | 625.0000 | 187.5000 | 2806.02 KB |       58.87 |
|                       |           |               |          |           |           |       |          |          |            |             |
| **LeanLucene_FuzzyQuery** | **presiden**  | **100000**        | **7.899 ms** | **0.1009 ms** | **0.0895 ms** |  **1.00** |        **-** |        **-** |   **30.61 KB** |        **1.00** |
| LuceneNet_FuzzyQuery  | presiden  | 100000        | 8.686 ms | 0.0270 ms | 0.0252 ms |  1.10 | 593.7500 | 218.7500 | 2844.58 KB |       92.93 |

## gutenberg-analysis

| Method                      | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0       | Gen1      | Gen2      | Allocated | Alloc Ratio |
|---------------------------- |---------:|--------:|--------:|------:|--------:|-----------:|----------:|----------:|----------:|------------:|
| LeanLucene_Standard_Analyse | 125.2 ms | 0.52 ms | 0.48 ms |  1.00 |    0.00 |  1400.0000 |  600.0000 |         - |   7.23 MB |        1.00 |
| LeanLucene_English_Analyse  | 395.4 ms | 2.27 ms | 2.12 ms |  3.16 |    0.02 | 11000.0000 | 6000.0000 | 2000.0000 | 113.03 MB |       15.62 |

## gutenberg-index

| Method                    | Mean       | Error   | StdDev  | Ratio | Gen0       | Gen1       | Gen2      | Allocated | Alloc Ratio |
|-------------------------- |-----------:|--------:|--------:|------:|-----------:|-----------:|----------:|----------:|------------:|
| LeanLucene_Standard_Index |   986.9 ms | 5.13 ms | 4.55 ms |  1.00 | 19000.0000 | 10000.0000 | 1000.0000 | 123.53 MB |        1.00 |
| LeanLucene_English_Index  | 1,008.0 ms | 8.05 ms | 7.53 ms |  1.02 | 36000.0000 | 12000.0000 | 2000.0000 | 217.76 MB |        1.76 |
| LuceneNet_Index           |   645.3 ms | 2.88 ms | 2.55 ms |  0.65 | 41000.0000 |  3000.0000 |         - | 207.69 MB |        1.68 |

## gutenberg-search

| Method                     | SearchTerm | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |----------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| **LeanLucene_Standard_Search** | **death**      | **11.38 μs** | **0.028 μs** | **0.026 μs** |  **1.00** |    **0.00** | **0.1068** |      **-** |     **472 B** |        **1.00** |
| LeanLucene_English_Search  | death      | 11.51 μs | 0.025 μs | 0.024 μs |  1.01 |    0.00 | 0.1068 |      - |     472 B |        1.00 |
| LuceneNet_Search           | death      | 23.33 μs | 0.433 μs | 0.405 μs |  2.05 |    0.03 | 2.6550 | 0.0305 |   11231 B |       23.79 |
|                            |            |          |          |          |       |         |        |        |           |             |
| **LeanLucene_Standard_Search** | **love**       | **15.20 μs** | **0.038 μs** | **0.035 μs** |  **1.00** |    **0.00** | **0.1068** |      **-** |     **464 B** |        **1.00** |
| LeanLucene_English_Search  | love       | 20.17 μs | 0.027 μs | 0.024 μs |  1.33 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LuceneNet_Search           | love       | 30.64 μs | 0.080 μs | 0.071 μs |  2.02 |    0.01 | 2.6245 | 0.0610 |   11175 B |       24.08 |
|                            |            |          |          |          |       |         |        |        |           |             |
| **LeanLucene_Standard_Search** | **man**        | **39.52 μs** | **0.091 μs** | **0.085 μs** |  **1.00** |    **0.00** | **0.0610** |      **-** |     **464 B** |        **1.00** |
| LeanLucene_English_Search  | man        | 39.83 μs | 0.097 μs | 0.091 μs |  1.01 |    0.00 | 0.0610 |      - |     464 B |        1.00 |
| LuceneNet_Search           | man        | 51.84 μs | 0.224 μs | 0.209 μs |  1.31 |    0.01 | 2.6245 | 0.0610 |   11038 B |       23.79 |
|                            |            |          |          |          |       |         |        |        |           |             |
| **LeanLucene_Standard_Search** | **night**      | **25.84 μs** | **0.057 μs** | **0.054 μs** |  **1.00** |    **0.00** | **0.0916** |      **-** |     **472 B** |        **1.00** |
| LeanLucene_English_Search  | night      | 26.51 μs | 0.050 μs | 0.046 μs |  1.03 |    0.00 | 0.0916 |      - |     472 B |        1.00 |
| LuceneNet_Search           | night      | 37.63 μs | 0.088 μs | 0.083 μs |  1.46 |    0.00 | 2.6245 | 0.0610 |   11223 B |       23.78 |
|                            |            |          |          |          |       |         |        |        |           |             |
| **LeanLucene_Standard_Search** | **sea**        | **12.83 μs** | **0.037 μs** | **0.035 μs** |  **1.00** |    **0.00** | **0.1068** |      **-** |     **464 B** |        **1.00** |
| LeanLucene_English_Search  | sea        | 13.84 μs | 0.031 μs | 0.029 μs |  1.08 |    0.00 | 0.1068 |      - |     464 B |        1.00 |
| LuceneNet_Search           | sea        | 27.23 μs | 0.078 μs | 0.073 μs |  2.12 |    0.01 | 2.6550 | 0.0305 |   11271 B |       24.29 |

## Indexing

| Method                    | DocumentCount | Mean     | Error    | StdDev   | Ratio | Gen0        | Gen1       | Gen2      | Allocated | Alloc Ratio |
|-------------------------- |-------------- |---------:|---------:|---------:|------:|------------:|-----------:|----------:|----------:|------------:|
| LeanLucene_IndexDocuments | 100000        | 10.796 s | 0.0286 s | 0.0254 s |  1.00 | 196000.0000 | 88000.0000 | 6000.0000 |   1.17 GB |        1.00 |
| LuceneNet_IndexDocuments  | 100000        |  7.138 s | 0.0184 s | 0.0163 s |  0.66 | 332000.0000 | 30000.0000 | 1000.0000 |   1.88 GB |        1.61 |

## Index-sort (index)

| Method                    | DocumentCount | Mean    | Error   | StdDev  | Ratio | Gen0        | Gen1       | Gen2      | Allocated | Alloc Ratio |
|-------------------------- |-------------- |--------:|--------:|--------:|------:|------------:|-----------:|----------:|----------:|------------:|
| LeanLucene_Index_Unsorted | 100000        | 11.29 s | 0.022 s | 0.021 s |  1.00 | 205000.0000 | 87000.0000 | 6000.0000 |   1.24 GB |        1.00 |
| LeanLucene_Index_Sorted   | 100000        | 12.27 s | 0.033 s | 0.029 s |  1.09 | 210000.0000 | 89000.0000 | 8000.0000 |   1.27 GB |        1.02 |

## Index-sort (search)

| Method                                   | DocumentCount | Mean     | Error   | StdDev  | Ratio | Gen0    | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------- |-------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| LeanLucene_SortedSearch_EarlyTermination | 100000        | 251.7 μs | 1.00 μs | 0.94 μs |  1.00 | 28.3203 | 0.9766 | 117.66 KB |        1.00 |
| LeanLucene_SortedSearch_PostSort         | 100000        | 248.7 μs | 0.62 μs | 0.58 μs |  0.99 | 28.3203 | 0.9766 | 117.66 KB |        1.00 |

## Phrase queries

| Method                 | PhraseType     | DocumentCount | Mean       | Error    | StdDev   | Ratio | Gen0    | Gen1    | Allocated | Alloc Ratio |
|----------------------- |--------------- |-------------- |-----------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| **LeanLucene_PhraseQuery** | **ExactThreeWord** | **100000**        |   **445.4 μs** |  **4.57 μs** |  **4.27 μs** |  **1.00** | **14.6484** |       **-** |  **59.77 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | ExactThreeWord | 100000        |   342.2 μs |  0.78 μs |  0.69 μs |  0.77 | 90.3320 |  0.4883 | 369.88 KB |        6.19 |
|                        |                |               |            |          |          |       |         |         |           |             |
| **LeanLucene_PhraseQuery** | **ExactTwoWord**   | **100000**        |   **338.1 μs** |  **4.67 μs** |  **4.14 μs** |  **1.00** | **10.2539** |       **-** |  **42.92 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | ExactTwoWord   | 100000        |   406.2 μs |  0.58 μs |  0.54 μs |  1.20 | 72.2656 | 18.0664 | 297.27 KB |        6.93 |
|                        |                |               |            |          |          |       |         |         |           |             |
| **LeanLucene_PhraseQuery** | **SlopTwoWord**    | **100000**        |   **993.1 μs** | **11.34 μs** | **10.61 μs** |  **1.00** | **11.7188** |       **-** |  **48.69 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | SlopTwoWord    | 100000        | 1,035.5 μs |  2.58 μs |  2.29 μs |  1.04 | 37.1094 |       - | 155.61 KB |        3.20 |

## Prefix queries

| Method                 | QueryPrefix | DocumentCount | Mean     | Error   | StdDev  | Ratio | Gen0    | Gen1   | Allocated | Alloc Ratio |
|----------------------- |------------ |-------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| **LeanLucene_PrefixQuery** | **gov**         | **100000**        | **149.7 μs** | **1.56 μs** | **1.38 μs** |  **1.00** |  **5.8594** |      **-** |  **23.67 KB** |        **1.00** |
| LuceneNet_PrefixQuery  | gov         | 100000        | 187.3 μs | 0.30 μs | 0.28 μs |  1.25 | 26.8555 | 0.2441 | 110.04 KB |        4.65 |
|                        |             |               |          |         |         |       |         |        |           |             |
| **LeanLucene_PrefixQuery** | **mark**        | **100000**        | **240.3 μs** | **1.19 μs** | **0.93 μs** |  **1.00** |  **8.5449** |      **-** |  **34.51 KB** |        **1.00** |
| LuceneNet_PrefixQuery  | mark        | 100000        | 284.1 μs | 0.71 μs | 0.66 μs |  1.18 | 30.7617 |      - | 126.09 KB |        3.65 |
|                        |             |               |          |         |         |       |         |        |           |             |
| **LeanLucene_PrefixQuery** | **pres**        | **100000**        | **290.0 μs** | **3.71 μs** | **3.29 μs** |  **1.00** | **15.6250** |      **-** |  **62.99 KB** |        **1.00** |
| LuceneNet_PrefixQuery  | pres        | 100000        | 355.8 μs | 0.61 μs | 0.57 μs |  1.23 | 32.2266 |      - | 133.65 KB |        2.12 |

## Term queries

| Method               | QueryTerm  | DocumentCount | Mean     | Error   | StdDev  | Ratio | Gen0    | Gen1   | Allocated | Alloc Ratio |
|--------------------- |----------- |-------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| **LeanLucene_TermQuery** | **government** | **100000**        | **106.4 μs** | **0.24 μs** | **0.22 μs** |  **1.00** |       **-** |      **-** |     **480 B** |        **1.00** |
| LuceneNet_TermQuery  | government | 100000        | 135.6 μs | 0.48 μs | 0.42 μs |  1.27 | 14.4043 |      - |   60896 B |      126.87 |
|                      |            |               |          |         |         |       |         |        |           |             |
| **LeanLucene_TermQuery** | **people**     | **100000**        | **151.1 μs** | **0.35 μs** | **0.33 μs** |  **1.00** |       **-** |      **-** |     **472 B** |        **1.00** |
| LuceneNet_TermQuery  | people     | 100000        | 175.4 μs | 0.41 μs | 0.36 μs |  1.16 | 13.9160 | 0.2441 |   58688 B |      124.34 |
|                      |            |               |          |         |         |       |         |        |           |             |
| **LeanLucene_TermQuery** | **said**       | **100000**        | **687.3 μs** | **1.09 μs** | **0.97 μs** |  **1.00** |       **-** |      **-** |     **464 B** |        **1.00** |
| LuceneNet_TermQuery  | said       | 100000        | 754.2 μs | 1.18 μs | 1.11 μs |  1.10 | 13.6719 |      - |   58720 B |      126.55 |

## Schema and JSON

| Method                      | DocumentCount | Mean        | Error    | StdDev   | Ratio | Gen0        | Gen1       | Gen2      | Allocated  | Alloc Ratio |
|---------------------------- |-------------- |------------:|---------:|---------:|------:|------------:|-----------:|----------:|-----------:|------------:|
| LeanLucene_Index_NoSchema   | 100000        | 10,553.3 ms | 33.23 ms | 31.09 ms |  1.00 | 192000.0000 | 82000.0000 | 2000.0000 | 1194.33 MB |        1.00 |
| LeanLucene_Index_WithSchema | 100000        | 10,507.9 ms | 43.30 ms | 40.50 ms |  1.00 | 193000.0000 | 83000.0000 | 2000.0000 | 1198.15 MB |        1.00 |
| LeanLucene_JsonMapping      | 100000        |    427.9 ms |  2.34 ms |  2.19 ms |  0.04 |  51000.0000 |  1000.0000 |         - |  215.88 MB |        0.18 |

## Suggester

| Method                 | DocumentCount | Mean      | Error     | StdDev    | Ratio | Gen0      | Gen1    | Allocated  | Alloc Ratio |
|----------------------- |-------------- |----------:|----------:|----------:|------:|----------:|--------:|-----------:|------------:|
| LeanLucene_DidYouMean  | 100000        |  4.635 ms | 0.0178 ms | 0.0148 ms |  1.00 |         - |       - |   24.91 KB |        1.00 |
| LeanLucene_SpellIndex  | 100000        |  4.678 ms | 0.0179 ms | 0.0149 ms |  1.01 |         - |       - |    23.2 KB |        0.93 |
| LuceneNet_SpellChecker | 100000        | 10.254 ms | 0.0299 ms | 0.0280 ms |  2.21 | 1296.8750 | 31.2500 | 5351.15 KB |      214.78 |

## Wildcard queries

| Method                   | WildcardPattern | DocumentCount | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------- |---------------- |-------------- |-----------:|---------:|---------:|------:|--------:|--------:|-------:|----------:|------------:|
| **LeanLucene_WildcardQuery** | **gov***            | **100000**        |   **150.2 μs** |  **0.80 μs** |  **0.67 μs** |  **1.00** |    **0.00** |  **6.1035** |      **-** |  **24.38 KB** |        **1.00** |
| LuceneNet_WildcardQuery  | gov*            | 100000        |   202.0 μs |  0.39 μs |  0.35 μs |  1.35 |    0.01 | 31.4941 |      - | 129.06 KB |        5.29 |
|                          |                 |               |            |          |          |       |         |         |        |           |             |
| **LeanLucene_WildcardQuery** | **m*rket**          | **100000**        |   **529.0 μs** | **10.49 μs** | **11.23 μs** |  **1.00** |    **0.00** |  **1.9531** |      **-** |  **10.17 KB** |        **1.00** |
| LuceneNet_WildcardQuery  | m*rket          | 100000        | 1,167.8 μs |  3.30 μs |  2.92 μs |  2.21 |    0.05 | 97.6563 | 9.7656 | 404.52 KB |       39.76 |
|                          |                 |               |            |          |          |       |         |         |        |           |             |
| **LeanLucene_WildcardQuery** | **pre*dent**        | **100000**        |   **106.5 μs** |  **0.81 μs** |  **0.75 μs** |  **1.00** |    **0.00** |  **2.0752** |      **-** |   **8.63 KB** |        **1.00** |
| LuceneNet_WildcardQuery  | pre*dent        | 100000        |   410.5 μs |  1.07 μs |  1.00 μs |  3.86 |    0.03 | 92.7734 |      - |  379.5 KB |       44.00 |

<details>
<summary>Full data (report.json)</summary>

<pre><code class="lang-json">{
  "schemaVersion": 2,
  "runId": "2026-05-09 23-07 (2431f4a)",
  "runType": "full",
  "generatedAtUtc": "2026-05-09T23:07:16.0665036\u002B00:00",
  "commandLineArgs": [],
  "hostMachineName": "debian",
  "commitHash": "2431f4a",
  "dotnetVersion": "10.0.3",
  "provenance": {
    "sourceCommit": "2431f4a",
    "sourceRef": "",
    "sourceManifestPath": "",
    "gitCommitHash": "2431f4a",
    "gitAvailable": true,
    "gitDirty": false,
    "benchmarkDotNetVersion": "0.16.0-nightly.20260427.506\u002Bc68dc1556c410c4bdfe21373c7689be5781fbaf9",
    "runtimeFramework": ".NET 10.0.3",
    "runtimeIdentifier": "linux-x64",
    "osDescription": "Debian GNU/Linux 13 (trixie)",
    "processArchitecture": "X64",
    "effectiveDocCount": 100000,
    "dataFingerprintSha256": "",
    "dataSources": []
  },
  "totalBenchmarkCount": 92,
  "suites": [
    {
      "suiteName": "analysis",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.AnalysisBenchmarks-20260510-002318",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "AnalysisBenchmarks.LeanLucene_Analyse|DocumentCount=100000",
          "displayInfo": "AnalysisBenchmarks.LeanLucene_Analyse: DefaultJob [DocumentCount=100000]",
          "typeName": "AnalysisBenchmarks",
          "methodName": "LeanLucene_Analyse",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1534872811.9333334,
            "medianNanoseconds": 1537830336,
            "minNanoseconds": 1523081160,
            "maxNanoseconds": 1542123753,
            "standardDeviationNanoseconds": 6784686.0211168155,
            "operationsPerSecond": 0.6515197821117146
          },
          "gc": {
            "bytesAllocatedPerOperation": 209429200,
            "gen0Collections": 49,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalysisBenchmarks.LuceneNet_Analyse|DocumentCount=100000",
          "displayInfo": "AnalysisBenchmarks.LuceneNet_Analyse: DefaultJob [DocumentCount=100000]",
          "typeName": "AnalysisBenchmarks",
          "methodName": "LuceneNet_Analyse",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 2255669329.214286,
            "medianNanoseconds": 2255240063,
            "minNanoseconds": 2251506735,
            "maxNanoseconds": 2261054176,
            "standardDeviationNanoseconds": 2545820.578249716,
            "operationsPerSecond": 0.44332739158550716
          },
          "gc": {
            "bytesAllocatedPerOperation": 604939928,
            "gen0Collections": 144,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "analysis-filters",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.TokenFilterBenchmarks-20260510-002924",
      "benchmarkCount": 10,
      "benchmarks": [
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=decimal-digit-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=decim(...)ating [22]]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "decimal-digit-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 89.16235450108846,
            "medianNanoseconds": 89.20604908466339,
            "minNanoseconds": 88.82974314689636,
            "maxNanoseconds": 89.37765991687775,
            "standardDeviationNanoseconds": 0.15541586766852403,
            "operationsPerSecond": 11215495.660646696
          },
          "gc": {
            "bytesAllocatedPerOperation": 120,
            "gen0Collections": 240,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=elision-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=elision-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "elision-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 154.58440512021383,
            "medianNanoseconds": 154.65079069137573,
            "minNanoseconds": 153.96258020401,
            "maxNanoseconds": 155.08847641944885,
            "standardDeviationNanoseconds": 0.39375547743575934,
            "operationsPerSecond": 6468957.843595813
          },
          "gc": {
            "bytesAllocatedPerOperation": 152,
            "gen0Collections": 152,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=length-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=length-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "length-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 53.042946100234985,
            "medianNanoseconds": 53.03507363796234,
            "minNanoseconds": 52.8838569521904,
            "maxNanoseconds": 53.168991684913635,
            "standardDeviationNanoseconds": 0.08897244139619027,
            "operationsPerSecond": 18852648.1562752
          },
          "gc": {
            "bytesAllocatedPerOperation": 104,
            "gen0Collections": 417,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=length-noop",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=length-noop]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "length-noop"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 47.658829080207006,
            "medianNanoseconds": 47.655495673418045,
            "minNanoseconds": 47.53961229324341,
            "maxNanoseconds": 47.82393229007721,
            "standardDeviationNanoseconds": 0.08369547392498726,
            "operationsPerSecond": 20982471.019526284
          },
          "gc": {
            "bytesAllocatedPerOperation": 104,
            "gen0Collections": 417,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=reverse-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=reverse-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "reverse-mutating"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 69.99959816382481,
            "medianNanoseconds": 70.02406990528107,
            "minNanoseconds": 69.80475628376007,
            "maxNanoseconds": 70.16595184803009,
            "standardDeviationNanoseconds": 0.10949921570063245,
            "operationsPerSecond": 14285796.293567745
          },
          "gc": {
            "bytesAllocatedPerOperation": 160,
            "gen0Collections": 320,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=shingle-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=shingle-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "shingle-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 259.5331671079,
            "medianNanoseconds": 259.3176212310791,
            "minNanoseconds": 258.3802351951599,
            "maxNanoseconds": 260.92907190322876,
            "standardDeviationNanoseconds": 0.7256760102112588,
            "operationsPerSecond": 3853072.0799328648
          },
          "gc": {
            "bytesAllocatedPerOperation": 504,
            "gen0Collections": 252,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=truncate-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=truncate-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "truncate-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 57.430476311842604,
            "medianNanoseconds": 57.465127825737,
            "minNanoseconds": 57.236072182655334,
            "maxNanoseconds": 57.683608651161194,
            "standardDeviationNanoseconds": 0.13316081810720773,
            "operationsPerSecond": 17412357.762280867
          },
          "gc": {
            "bytesAllocatedPerOperation": 128,
            "gen0Collections": 513,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=truncate-noop",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=truncate-noop]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "truncate-noop"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 43.20392416630472,
            "medianNanoseconds": 43.20649603009224,
            "minNanoseconds": 43.07581615447998,
            "maxNanoseconds": 43.4106268286705,
            "standardDeviationNanoseconds": 0.09007155235559337,
            "operationsPerSecond": 23146045.62656631
          },
          "gc": {
            "bytesAllocatedPerOperation": 104,
            "gen0Collections": 417,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=unique-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=unique-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "unique-mutating"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 150.7703288112368,
            "medianNanoseconds": 150.76097071170807,
            "minNanoseconds": 150.14886045455933,
            "maxNanoseconds": 151.47344636917114,
            "standardDeviationNanoseconds": 0.3177878029038432,
            "operationsPerSecond": 6632604.756417237
          },
          "gc": {
            "bytesAllocatedPerOperation": 296,
            "gen0Collections": 296,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=word-delimiter-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: DefaultJob [Scenario=word-(...)ating [23]]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "word-delimiter-mutating"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 447.43072137832644,
            "medianNanoseconds": 447.46702909469604,
            "minNanoseconds": 446.0069179534912,
            "maxNanoseconds": 449.1734504699707,
            "standardDeviationNanoseconds": 0.8275704948430855,
            "operationsPerSecond": 2234982.874934166
          },
          "gc": {
            "bytesAllocatedPerOperation": 928,
            "gen0Collections": 465,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "analysis-parity",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.AnalyserParityBenchmarks-20260510-002628",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "AnalyserParityBenchmarks.LeanLucene_Keyword",
          "displayInfo": "AnalyserParityBenchmarks.LeanLucene_Keyword: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanLucene_Keyword",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 3992.879215494792,
            "medianNanoseconds": 3992.4408111572266,
            "minNanoseconds": 3982.960159301758,
            "maxNanoseconds": 4002.265411376953,
            "standardDeviationNanoseconds": 6.225780938098402,
            "operationsPerSecond": 250445.8427190569
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LeanLucene_Simple",
          "displayInfo": "AnalyserParityBenchmarks.LeanLucene_Simple: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanLucene_Simple",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 39650.830249023435,
            "medianNanoseconds": 39670.037048339844,
            "minNanoseconds": 39518.768981933594,
            "maxNanoseconds": 39774.692626953125,
            "standardDeviationNanoseconds": 76.76537824091557,
            "operationsPerSecond": 25220.15286236356
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LeanLucene_Whitespace",
          "displayInfo": "AnalyserParityBenchmarks.LeanLucene_Whitespace: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanLucene_Whitespace",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 39058.38391927083,
            "medianNanoseconds": 39070.439392089844,
            "minNanoseconds": 38969.601318359375,
            "maxNanoseconds": 39148.749084472656,
            "standardDeviationNanoseconds": 47.89228275888441,
            "operationsPerSecond": 25602.697798938236
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LuceneNet_Keyword",
          "displayInfo": "AnalyserParityBenchmarks.LuceneNet_Keyword: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LuceneNet_Keyword",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 12566.30550842285,
            "medianNanoseconds": 12571.542739868164,
            "minNanoseconds": 12537.5732421875,
            "maxNanoseconds": 12591.767852783203,
            "standardDeviationNanoseconds": 20.201597786327447,
            "operationsPerSecond": 79577.88383624188
          },
          "gc": {
            "bytesAllocatedPerOperation": 3200,
            "gen0Collections": 50,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LuceneNet_Simple",
          "displayInfo": "AnalyserParityBenchmarks.LuceneNet_Simple: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LuceneNet_Simple",
          "parameters": {},
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 84560.17690604074,
            "medianNanoseconds": 84522.9951171875,
            "minNanoseconds": 84393.15319824219,
            "maxNanoseconds": 84837.52026367188,
            "standardDeviationNanoseconds": 136.75370559058564,
            "operationsPerSecond": 11825.897681259023
          },
          "gc": {
            "bytesAllocatedPerOperation": 3200,
            "gen0Collections": 6,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LuceneNet_Whitespace",
          "displayInfo": "AnalyserParityBenchmarks.LuceneNet_Whitespace: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LuceneNet_Whitespace",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 76249.91119791666,
            "medianNanoseconds": 76272.79772949219,
            "minNanoseconds": 76020.13171386719,
            "maxNanoseconds": 76539.83935546875,
            "standardDeviationNanoseconds": 144.34491002674122,
            "operationsPerSecond": 13114.769372050396
          },
          "gc": {
            "bytesAllocatedPerOperation": 3200,
            "gen0Collections": 6,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "blockjoin",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.BlockJoinBenchmarks-20260510-013742",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "BlockJoinBenchmarks.LeanLucene_BlockJoinQuery|BlockCount=500",
          "displayInfo": "BlockJoinBenchmarks.LeanLucene_BlockJoinQuery: DefaultJob [BlockCount=500]",
          "typeName": "BlockJoinBenchmarks",
          "methodName": "LeanLucene_BlockJoinQuery",
          "parameters": {
            "BlockCount": "500"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 7160.064981587728,
            "medianNanoseconds": 7161.31201171875,
            "minNanoseconds": 7133.332588195801,
            "maxNanoseconds": 7176.329460144043,
            "standardDeviationNanoseconds": 11.78537805357379,
            "operationsPerSecond": 139663.53693318748
          },
          "gc": {
            "bytesAllocatedPerOperation": 720,
            "gen0Collections": 22,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BlockJoinBenchmarks.LeanLucene_IndexBlocks|BlockCount=500",
          "displayInfo": "BlockJoinBenchmarks.LeanLucene_IndexBlocks: DefaultJob [BlockCount=500]",
          "typeName": "BlockJoinBenchmarks",
          "methodName": "LeanLucene_IndexBlocks",
          "parameters": {
            "BlockCount": "500"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 82662240.26530613,
            "medianNanoseconds": 82646298.85714287,
            "minNanoseconds": 82159033.71428572,
            "maxNanoseconds": 83290953.57142857,
            "standardDeviationNanoseconds": 312490.9511109331,
            "operationsPerSecond": 12.097421952157113
          },
          "gc": {
            "bytesAllocatedPerOperation": 13892496,
            "gen0Collections": 12,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        },
        {
          "key": "BlockJoinBenchmarks.LuceneNet_IndexBlocks|BlockCount=500",
          "displayInfo": "BlockJoinBenchmarks.LuceneNet_IndexBlocks: DefaultJob [BlockCount=500]",
          "typeName": "BlockJoinBenchmarks",
          "methodName": "LuceneNet_IndexBlocks",
          "parameters": {
            "BlockCount": "500"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 56608486.452380955,
            "medianNanoseconds": 56632252.222222224,
            "minNanoseconds": 56033699.333333336,
            "maxNanoseconds": 57255062.11111111,
            "standardDeviationNanoseconds": 353609.2058222753,
            "operationsPerSecond": 17.66519585082353
          },
          "gc": {
            "bytesAllocatedPerOperation": 28714791,
            "gen0Collections": 45,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        },
        {
          "key": "BlockJoinBenchmarks.LuceneNet_ToParentBlockJoinQuery|BlockCount=500",
          "displayInfo": "BlockJoinBenchmarks.LuceneNet_ToParentBlockJoinQuery: DefaultJob [BlockCount=500]",
          "typeName": "BlockJoinBenchmarks",
          "methodName": "LuceneNet_ToParentBlockJoinQuery",
          "parameters": {
            "BlockCount": "500"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 21838.541259765625,
            "medianNanoseconds": 21837.888626098633,
            "minNanoseconds": 21747.815368652344,
            "maxNanoseconds": 21911.04180908203,
            "standardDeviationNanoseconds": 45.578915758500294,
            "operationsPerSecond": 45790.60423977843
          },
          "gc": {
            "bytesAllocatedPerOperation": 12888,
            "gen0Collections": 100,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "boolean",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.BooleanQueryBenchmarks-20260510-003348",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery|BooleanType=Must, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery: DefaultJob [BooleanType=Must, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanLucene_BooleanQuery",
          "parameters": {
            "BooleanType": "Must",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 267250.4052358774,
            "medianNanoseconds": 266851.08984375,
            "minNanoseconds": 263726.9912109375,
            "maxNanoseconds": 271095.7431640625,
            "standardDeviationNanoseconds": 2111.940368235893,
            "operationsPerSecond": 3741.8091063973948
          },
          "gc": {
            "bytesAllocatedPerOperation": 13243,
            "gen0Collections": 6,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery|BooleanType=MustNot, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery: DefaultJob [BooleanType=MustNot, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanLucene_BooleanQuery",
          "parameters": {
            "BooleanType": "MustNot",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 173508.37941196986,
            "medianNanoseconds": 173734.86279296875,
            "minNanoseconds": 172135.2177734375,
            "maxNanoseconds": 175102.13208007812,
            "standardDeviationNanoseconds": 942.4613760372381,
            "operationsPerSecond": 5763.410409278555
          },
          "gc": {
            "bytesAllocatedPerOperation": 13619,
            "gen0Collections": 13,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery|BooleanType=Should, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LeanLucene_BooleanQuery: DefaultJob [BooleanType=Should, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanLucene_BooleanQuery",
          "parameters": {
            "BooleanType": "Should",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 221947.71564127604,
            "medianNanoseconds": 221962.61596679688,
            "minNanoseconds": 219711.97998046875,
            "maxNanoseconds": 225172.18359375,
            "standardDeviationNanoseconds": 1597.5867988216764,
            "operationsPerSecond": 4505.565633377612
          },
          "gc": {
            "bytesAllocatedPerOperation": 14022,
            "gen0Collections": 13,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanType=Must, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: DefaultJob [BooleanType=Must, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanType": "Must",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 484884.70455496653,
            "medianNanoseconds": 484566.9147949219,
            "minNanoseconds": 482703.47802734375,
            "maxNanoseconds": 487050.34716796875,
            "standardDeviationNanoseconds": 1290.3579083598509,
            "operationsPerSecond": 2062.345936273269
          },
          "gc": {
            "bytesAllocatedPerOperation": 147552,
            "gen0Collections": 72,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanType=MustNot, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: DefaultJob [BooleanType=MustNot, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanType": "MustNot",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 403646.10110677086,
            "medianNanoseconds": 407434.44140625,
            "minNanoseconds": 390829.34228515625,
            "maxNanoseconds": 409587.2138671875,
            "standardDeviationNanoseconds": 7264.849857890558,
            "operationsPerSecond": 2477.4177113517667
          },
          "gc": {
            "bytesAllocatedPerOperation": 152640,
            "gen0Collections": 74,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanType=Should, DocumentCount=100000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: DefaultJob [BooleanType=Should, DocumentCount=100000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanType": "Should",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 587231.5689453125,
            "medianNanoseconds": 586922.4736328125,
            "minNanoseconds": 584555.4267578125,
            "maxNanoseconds": 590260.091796875,
            "standardDeviationNanoseconds": 1539.033709828149,
            "operationsPerSecond": 1702.9057238799905
          },
          "gc": {
            "bytesAllocatedPerOperation": 711688,
            "gen0Collections": 174,
            "gen1Collections": 41,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "deletion",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.DeletionBenchmarks-20260510-010036",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "DeletionBenchmarks.LeanLucene_DeleteDocuments|DocumentCount=100000",
          "displayInfo": "DeletionBenchmarks.LeanLucene_DeleteDocuments: DefaultJob [DocumentCount=100000]",
          "typeName": "DeletionBenchmarks",
          "methodName": "LeanLucene_DeleteDocuments",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10914036193.066668,
            "medianNanoseconds": 10906409250,
            "minNanoseconds": 10840531864,
            "maxNanoseconds": 11002134920,
            "standardDeviationNanoseconds": 44762079.00867586,
            "operationsPerSecond": 0.09162513137305404
          },
          "gc": {
            "bytesAllocatedPerOperation": 1279394048,
            "gen0Collections": 199,
            "gen1Collections": 89,
            "gen2Collections": 9
          }
        },
        {
          "key": "DeletionBenchmarks.LuceneNet_DeleteDocuments|DocumentCount=100000",
          "displayInfo": "DeletionBenchmarks.LuceneNet_DeleteDocuments: DefaultJob [DocumentCount=100000]",
          "typeName": "DeletionBenchmarks",
          "methodName": "LuceneNet_DeleteDocuments",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 7202568965.4,
            "medianNanoseconds": 7205800981,
            "minNanoseconds": 7157342901,
            "maxNanoseconds": 7266386170,
            "standardDeviationNanoseconds": 30456811.03559944,
            "operationsPerSecond": 0.1388393509043567
          },
          "gc": {
            "bytesAllocatedPerOperation": 2055213080,
            "gen0Collections": 339,
            "gen1Collections": 34,
            "gen2Collections": 1
          }
        }
      ]
    },
    {
      "suiteName": "fuzzy",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.FuzzyQueryBenchmarks-20260510-004952",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery|DocumentCount=100000, QueryTerm=goverment",
          "displayInfo": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery: DefaultJob [QueryTerm=goverment, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanLucene_FuzzyQuery",
          "parameters": {
            "QueryTerm": "goverment",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 6894466.470982143,
            "medianNanoseconds": 6872726.99609375,
            "minNanoseconds": 6833109.5859375,
            "maxNanoseconds": 6973406.625,
            "standardDeviationNanoseconds": 50097.36640066103,
            "operationsPerSecond": 145.04385570788716
          },
          "gc": {
            "bytesAllocatedPerOperation": 26502,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery|DocumentCount=100000, QueryTerm=markts",
          "displayInfo": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery: DefaultJob [QueryTerm=markts, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanLucene_FuzzyQuery",
          "parameters": {
            "QueryTerm": "markts",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 7525470.781808035,
            "medianNanoseconds": 7529832.18359375,
            "minNanoseconds": 7462458.546875,
            "maxNanoseconds": 7606399.46875,
            "standardDeviationNanoseconds": 40275.27966219745,
            "operationsPerSecond": 132.88205203286225
          },
          "gc": {
            "bytesAllocatedPerOperation": 48808,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery|DocumentCount=100000, QueryTerm=presiden",
          "displayInfo": "FuzzyQueryBenchmarks.LeanLucene_FuzzyQuery: DefaultJob [QueryTerm=presiden, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanLucene_FuzzyQuery",
          "parameters": {
            "QueryTerm": "presiden",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 7899314.948660715,
            "medianNanoseconds": 7885611.4609375,
            "minNanoseconds": 7801108.21875,
            "maxNanoseconds": 8099217.71875,
            "standardDeviationNanoseconds": 89478.83385346529,
            "operationsPerSecond": 126.59325606070999
          },
          "gc": {
            "bytesAllocatedPerOperation": 31345,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=100000, QueryTerm=goverment",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: DefaultJob [QueryTerm=goverment, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "QueryTerm": "goverment",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 8673860.920833332,
            "medianNanoseconds": 8671171.140625,
            "minNanoseconds": 8623530.96875,
            "maxNanoseconds": 8725568.171875,
            "standardDeviationNanoseconds": 29661.08106813232,
            "operationsPerSecond": 115.28891333709856
          },
          "gc": {
            "bytesAllocatedPerOperation": 2939746,
            "gen0Collections": 38,
            "gen1Collections": 13,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=100000, QueryTerm=markts",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: DefaultJob [QueryTerm=markts, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "QueryTerm": "markts",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 9247042.357291667,
            "medianNanoseconds": 9252333.3125,
            "minNanoseconds": 9200708.25,
            "maxNanoseconds": 9297066.609375,
            "standardDeviationNanoseconds": 25007.770840967743,
            "operationsPerSecond": 108.14268620835932
          },
          "gc": {
            "bytesAllocatedPerOperation": 2873368,
            "gen0Collections": 40,
            "gen1Collections": 12,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=100000, QueryTerm=presiden",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: DefaultJob [QueryTerm=presiden, DocumentCount=100000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "QueryTerm": "presiden",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 8686283.18125,
            "medianNanoseconds": 8682509.21875,
            "minNanoseconds": 8657350.421875,
            "maxNanoseconds": 8740686.796875,
            "standardDeviationNanoseconds": 25248.912281464138,
            "operationsPerSecond": 115.12403857136222
          },
          "gc": {
            "bytesAllocatedPerOperation": 2912850,
            "gen0Collections": 38,
            "gen1Collections": 14,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-analysis",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.GutenbergAnalysisBenchmarks-20260510-014037",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "GutenbergAnalysisBenchmarks.LeanLucene_English_Analyse",
          "displayInfo": "GutenbergAnalysisBenchmarks.LeanLucene_English_Analyse: DefaultJob",
          "typeName": "GutenbergAnalysisBenchmarks",
          "methodName": "LeanLucene_English_Analyse",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 395442141.6,
            "medianNanoseconds": 396103825,
            "minNanoseconds": 391417090,
            "maxNanoseconds": 397880207,
            "standardDeviationNanoseconds": 2121357.6002296195,
            "operationsPerSecond": 2.528814951168067
          },
          "gc": {
            "bytesAllocatedPerOperation": 118524568,
            "gen0Collections": 11,
            "gen1Collections": 6,
            "gen2Collections": 2
          }
        },
        {
          "key": "GutenbergAnalysisBenchmarks.LeanLucene_Standard_Analyse",
          "displayInfo": "GutenbergAnalysisBenchmarks.LeanLucene_Standard_Analyse: DefaultJob",
          "typeName": "GutenbergAnalysisBenchmarks",
          "methodName": "LeanLucene_Standard_Analyse",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 125178821.62666665,
            "medianNanoseconds": 124961364,
            "minNanoseconds": 124611520.6,
            "maxNanoseconds": 126098394.6,
            "standardDeviationNanoseconds": 484067.1460726304,
            "operationsPerSecond": 7.988571764818175
          },
          "gc": {
            "bytesAllocatedPerOperation": 7585864,
            "gen0Collections": 7,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-index",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.GutenbergIndexingBenchmarks-20260510-014232",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "GutenbergIndexingBenchmarks.LeanLucene_English_Index",
          "displayInfo": "GutenbergIndexingBenchmarks.LeanLucene_English_Index: DefaultJob",
          "typeName": "GutenbergIndexingBenchmarks",
          "methodName": "LeanLucene_English_Index",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1007988459.9333333,
            "medianNanoseconds": 1006021545,
            "minNanoseconds": 998669771,
            "maxNanoseconds": 1020999837,
            "standardDeviationNanoseconds": 7528346.378334483,
            "operationsPerSecond": 0.9920748498114139
          },
          "gc": {
            "bytesAllocatedPerOperation": 228335848,
            "gen0Collections": 36,
            "gen1Collections": 12,
            "gen2Collections": 2
          }
        },
        {
          "key": "GutenbergIndexingBenchmarks.LeanLucene_Standard_Index",
          "displayInfo": "GutenbergIndexingBenchmarks.LeanLucene_Standard_Index: DefaultJob",
          "typeName": "GutenbergIndexingBenchmarks",
          "methodName": "LeanLucene_Standard_Index",
          "parameters": {},
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 986852831.5,
            "medianNanoseconds": 988080273,
            "minNanoseconds": 979665601,
            "maxNanoseconds": 995977335,
            "standardDeviationNanoseconds": 4547868.748453749,
            "operationsPerSecond": 1.0133223192763368
          },
          "gc": {
            "bytesAllocatedPerOperation": 129531536,
            "gen0Collections": 19,
            "gen1Collections": 10,
            "gen2Collections": 1
          }
        },
        {
          "key": "GutenbergIndexingBenchmarks.LuceneNet_Index",
          "displayInfo": "GutenbergIndexingBenchmarks.LuceneNet_Index: DefaultJob",
          "typeName": "GutenbergIndexingBenchmarks",
          "methodName": "LuceneNet_Index",
          "parameters": {},
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 645339395.0714285,
            "medianNanoseconds": 644461499.5,
            "minNanoseconds": 641127861,
            "maxNanoseconds": 649507494,
            "standardDeviationNanoseconds": 2554848.621751664,
            "operationsPerSecond": 1.5495722214344536
          },
          "gc": {
            "bytesAllocatedPerOperation": 217773632,
            "gen0Collections": 41,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-search",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.GutenbergSearchBenchmarks-20260510-014518",
      "benchmarkCount": 15,
      "benchmarks": [
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_English_Search|SearchTerm=death",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_English_Search: DefaultJob [SearchTerm=death]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_English_Search",
          "parameters": {
            "SearchTerm": "death"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 11511.981513468425,
            "medianNanoseconds": 11505.480590820312,
            "minNanoseconds": 11479.840805053711,
            "maxNanoseconds": 11553.4013671875,
            "standardDeviationNanoseconds": 23.501263043677724,
            "operationsPerSecond": 86866.01857638944
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_English_Search|SearchTerm=love",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_English_Search: DefaultJob [SearchTerm=love]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_English_Search",
          "parameters": {
            "SearchTerm": "love"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 20169.113006591797,
            "medianNanoseconds": 20171.648315429688,
            "minNanoseconds": 20134.980743408203,
            "maxNanoseconds": 20212.824615478516,
            "standardDeviationNanoseconds": 23.627216463480572,
            "operationsPerSecond": 49580.76240998668
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_English_Search|SearchTerm=man",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_English_Search: DefaultJob [SearchTerm=man]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_English_Search",
          "parameters": {
            "SearchTerm": "man"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 39834.45678304036,
            "medianNanoseconds": 39821.45837402344,
            "minNanoseconds": 39656.30828857422,
            "maxNanoseconds": 39986.75555419922,
            "standardDeviationNanoseconds": 91.05539847359128,
            "operationsPerSecond": 25103.89448628688
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_English_Search|SearchTerm=night",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_English_Search: DefaultJob [SearchTerm=night]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_English_Search",
          "parameters": {
            "SearchTerm": "night"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 26514.84369913737,
            "medianNanoseconds": 26520.26336669922,
            "minNanoseconds": 26443.297729492188,
            "maxNanoseconds": 26604.553436279297,
            "standardDeviationNanoseconds": 46.3028145108657,
            "operationsPerSecond": 37714.72354681592
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_English_Search|SearchTerm=sea",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_English_Search: DefaultJob [SearchTerm=sea]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_English_Search",
          "parameters": {
            "SearchTerm": "sea"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 13838.054491170247,
            "medianNanoseconds": 13839.110412597656,
            "minNanoseconds": 13786.762924194336,
            "maxNanoseconds": 13885.176055908203,
            "standardDeviationNanoseconds": 28.695481130270004,
            "operationsPerSecond": 72264.4935845626
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search|SearchTerm=death",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search: DefaultJob [SearchTerm=death]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_Standard_Search",
          "parameters": {
            "SearchTerm": "death"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 11377.11216023763,
            "medianNanoseconds": 11371.448501586914,
            "minNanoseconds": 11333.350997924805,
            "maxNanoseconds": 11422.493728637695,
            "standardDeviationNanoseconds": 26.26849569224008,
            "operationsPerSecond": 87895.76703787311
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search|SearchTerm=love",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search: DefaultJob [SearchTerm=love]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_Standard_Search",
          "parameters": {
            "SearchTerm": "love"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 15198.220353190105,
            "medianNanoseconds": 15203.903335571289,
            "minNanoseconds": 15142.073455810547,
            "maxNanoseconds": 15269.737319946289,
            "standardDeviationNanoseconds": 35.38491697092195,
            "operationsPerSecond": 65797.17735110348
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search|SearchTerm=man",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search: DefaultJob [SearchTerm=man]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_Standard_Search",
          "parameters": {
            "SearchTerm": "man"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 39522.06903076172,
            "medianNanoseconds": 39496.31384277344,
            "minNanoseconds": 39392.75988769531,
            "maxNanoseconds": 39695.23162841797,
            "standardDeviationNanoseconds": 85.15884410907566,
            "operationsPerSecond": 25302.319046648525
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search|SearchTerm=night",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search: DefaultJob [SearchTerm=night]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_Standard_Search",
          "parameters": {
            "SearchTerm": "night"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 25839.91415608724,
            "medianNanoseconds": 25834.012145996094,
            "minNanoseconds": 25767.961822509766,
            "maxNanoseconds": 25963.037811279297,
            "standardDeviationNanoseconds": 53.725149089860764,
            "operationsPerSecond": 38699.81896841653
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search|SearchTerm=sea",
          "displayInfo": "GutenbergSearchBenchmarks.LeanLucene_Standard_Search: DefaultJob [SearchTerm=sea]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanLucene_Standard_Search",
          "parameters": {
            "SearchTerm": "sea"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 12832.652822875976,
            "medianNanoseconds": 12835.552917480469,
            "minNanoseconds": 12760.939361572266,
            "maxNanoseconds": 12885.266082763672,
            "standardDeviationNanoseconds": 34.737411845222674,
            "operationsPerSecond": 77926.21009876943
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LuceneNet_Search|SearchTerm=death",
          "displayInfo": "GutenbergSearchBenchmarks.LuceneNet_Search: DefaultJob [SearchTerm=death]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LuceneNet_Search",
          "parameters": {
            "SearchTerm": "death"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 23328.759912109374,
            "medianNanoseconds": 23593.618225097656,
            "minNanoseconds": 22727.45474243164,
            "maxNanoseconds": 23709.8984375,
            "standardDeviationNanoseconds": 404.91305634060086,
            "operationsPerSecond": 42865.54466536068
          },
          "gc": {
            "bytesAllocatedPerOperation": 11231,
            "gen0Collections": 87,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LuceneNet_Search|SearchTerm=love",
          "displayInfo": "GutenbergSearchBenchmarks.LuceneNet_Search: DefaultJob [SearchTerm=love]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LuceneNet_Search",
          "parameters": {
            "SearchTerm": "love"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 30639.855202811104,
            "medianNanoseconds": 30621.275939941406,
            "minNanoseconds": 30552.50860595703,
            "maxNanoseconds": 30784.039916992188,
            "standardDeviationNanoseconds": 71.08666396702301,
            "operationsPerSecond": 32637.22995362763
          },
          "gc": {
            "bytesAllocatedPerOperation": 11175,
            "gen0Collections": 43,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LuceneNet_Search|SearchTerm=man",
          "displayInfo": "GutenbergSearchBenchmarks.LuceneNet_Search: DefaultJob [SearchTerm=man]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LuceneNet_Search",
          "parameters": {
            "SearchTerm": "man"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 51835.99336344401,
            "medianNanoseconds": 51864.08850097656,
            "minNanoseconds": 51403.298583984375,
            "maxNanoseconds": 52107.108337402344,
            "standardDeviationNanoseconds": 209.3875414005578,
            "operationsPerSecond": 19291.614477002076
          },
          "gc": {
            "bytesAllocatedPerOperation": 11038,
            "gen0Collections": 43,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LuceneNet_Search|SearchTerm=night",
          "displayInfo": "GutenbergSearchBenchmarks.LuceneNet_Search: DefaultJob [SearchTerm=night]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LuceneNet_Search",
          "parameters": {
            "SearchTerm": "night"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 37631.58152669271,
            "medianNanoseconds": 37626.08184814453,
            "minNanoseconds": 37495.673828125,
            "maxNanoseconds": 37750.358642578125,
            "standardDeviationNanoseconds": 82.72569217651765,
            "operationsPerSecond": 26573.42475204459
          },
          "gc": {
            "bytesAllocatedPerOperation": 11223,
            "gen0Collections": 43,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LuceneNet_Search|SearchTerm=sea",
          "displayInfo": "GutenbergSearchBenchmarks.LuceneNet_Search: DefaultJob [SearchTerm=sea]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LuceneNet_Search",
          "parameters": {
            "SearchTerm": "sea"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 27231.01461385091,
            "medianNanoseconds": 27241.180908203125,
            "minNanoseconds": 27095.937866210938,
            "maxNanoseconds": 27360.835357666016,
            "standardDeviationNanoseconds": 73.07765026802048,
            "operationsPerSecond": 36722.83292343265
          },
          "gc": {
            "bytesAllocatedPerOperation": 11271,
            "gen0Collections": 87,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "index",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.IndexingBenchmarks-20260510-001344",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexingBenchmarks.LeanLucene_IndexDocuments|DocumentCount=100000",
          "displayInfo": "IndexingBenchmarks.LeanLucene_IndexDocuments: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexingBenchmarks",
          "methodName": "LeanLucene_IndexDocuments",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 10795651311.928572,
            "medianNanoseconds": 10792399180.5,
            "minNanoseconds": 10748470683,
            "maxNanoseconds": 10852199203,
            "standardDeviationNanoseconds": 25363655.02763194,
            "operationsPerSecond": 0.0926298906018813
          },
          "gc": {
            "bytesAllocatedPerOperation": 1252326464,
            "gen0Collections": 196,
            "gen1Collections": 88,
            "gen2Collections": 6
          }
        },
        {
          "key": "IndexingBenchmarks.LuceneNet_IndexDocuments|DocumentCount=100000",
          "displayInfo": "IndexingBenchmarks.LuceneNet_IndexDocuments: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexingBenchmarks",
          "methodName": "LuceneNet_IndexDocuments",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 7137549299.428572,
            "medianNanoseconds": 7139144301,
            "minNanoseconds": 7093127962,
            "maxNanoseconds": 7156706060,
            "standardDeviationNanoseconds": 16288030.19287997,
            "operationsPerSecond": 0.1401041110959555
          },
          "gc": {
            "bytesAllocatedPerOperation": 2019255928,
            "gen0Collections": 332,
            "gen1Collections": 30,
            "gen2Collections": 1
          }
        }
      ]
    },
    {
      "suiteName": "indexsort-index",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.IndexSortIndexBenchmarks-20260510-012431",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexSortIndexBenchmarks.LeanLucene_Index_Sorted|DocumentCount=100000",
          "displayInfo": "IndexSortIndexBenchmarks.LeanLucene_Index_Sorted: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexSortIndexBenchmarks",
          "methodName": "LeanLucene_Index_Sorted",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 12272045936.142857,
            "medianNanoseconds": 12270272601.5,
            "minNanoseconds": 12231449094,
            "maxNanoseconds": 12328025847,
            "standardDeviationNanoseconds": 28988852.194004346,
            "operationsPerSecond": 0.08148600528416072
          },
          "gc": {
            "bytesAllocatedPerOperation": 1358499624,
            "gen0Collections": 210,
            "gen1Collections": 89,
            "gen2Collections": 8
          }
        },
        {
          "key": "IndexSortIndexBenchmarks.LeanLucene_Index_Unsorted|DocumentCount=100000",
          "displayInfo": "IndexSortIndexBenchmarks.LeanLucene_Index_Unsorted: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexSortIndexBenchmarks",
          "methodName": "LeanLucene_Index_Unsorted",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 11287520018.8,
            "medianNanoseconds": 11292563659,
            "minNanoseconds": 11248221416,
            "maxNanoseconds": 11321863857,
            "standardDeviationNanoseconds": 21002506.247532345,
            "operationsPerSecond": 0.08859341984195322
          },
          "gc": {
            "bytesAllocatedPerOperation": 1333960792,
            "gen0Collections": 205,
            "gen1Collections": 87,
            "gen2Collections": 6
          }
        }
      ]
    },
    {
      "suiteName": "indexsort-search",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.IndexSortSearchBenchmarks-20260510-013513",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexSortSearchBenchmarks.LeanLucene_SortedSearch_EarlyTermination|DocumentCount=100000",
          "displayInfo": "IndexSortSearchBenchmarks.LeanLucene_SortedSearch_EarlyTermination: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexSortSearchBenchmarks",
          "methodName": "LeanLucene_SortedSearch_EarlyTermination",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 251697.93577473957,
            "medianNanoseconds": 251349.19287109375,
            "minNanoseconds": 250309.8515625,
            "maxNanoseconds": 253359.19775390625,
            "standardDeviationNanoseconds": 937.2736151546011,
            "operationsPerSecond": 3973.016294003155
          },
          "gc": {
            "bytesAllocatedPerOperation": 120488,
            "gen0Collections": 58,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        },
        {
          "key": "IndexSortSearchBenchmarks.LeanLucene_SortedSearch_PostSort|DocumentCount=100000",
          "displayInfo": "IndexSortSearchBenchmarks.LeanLucene_SortedSearch_PostSort: DefaultJob [DocumentCount=100000]",
          "typeName": "IndexSortSearchBenchmarks",
          "methodName": "LeanLucene_SortedSearch_PostSort",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 248680.13483072916,
            "medianNanoseconds": 248710.94873046875,
            "minNanoseconds": 247633.36181640625,
            "maxNanoseconds": 249804.02734375,
            "standardDeviationNanoseconds": 575.9541503468995,
            "operationsPerSecond": 4021.229925263942
          },
          "gc": {
            "bytesAllocatedPerOperation": 120488,
            "gen0Collections": 58,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "phrase",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.PhraseQueryBenchmarks-20260510-003918",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery|DocumentCount=100000, PhraseType=ExactThreeWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery: DefaultJob [PhraseType=ExactThreeWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanLucene_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactThreeWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 445364.9908854167,
            "medianNanoseconds": 443748.84423828125,
            "minNanoseconds": 441411.29052734375,
            "maxNanoseconds": 455031.8466796875,
            "standardDeviationNanoseconds": 4270.17122831497,
            "operationsPerSecond": 2245.349366172519
          },
          "gc": {
            "bytesAllocatedPerOperation": 61204,
            "gen0Collections": 30,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery|DocumentCount=100000, PhraseType=ExactTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery: DefaultJob [PhraseType=ExactTwoWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanLucene_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactTwoWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 338125.3524344308,
            "medianNanoseconds": 338887.8278808594,
            "minNanoseconds": 330014.29443359375,
            "maxNanoseconds": 345950.9453125,
            "standardDeviationNanoseconds": 4137.171900820816,
            "operationsPerSecond": 2957.4830541401648
          },
          "gc": {
            "bytesAllocatedPerOperation": 43950,
            "gen0Collections": 21,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery|DocumentCount=100000, PhraseType=SlopTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanLucene_PhraseQuery: DefaultJob [PhraseType=SlopTwoWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanLucene_PhraseQuery",
          "parameters": {
            "PhraseType": "SlopTwoWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 993108.1602864583,
            "medianNanoseconds": 991918.44921875,
            "minNanoseconds": 977289.4453125,
            "maxNanoseconds": 1010675.990234375,
            "standardDeviationNanoseconds": 10606.95573949675,
            "operationsPerSecond": 1006.9396667846871
          },
          "gc": {
            "bytesAllocatedPerOperation": 49855,
            "gen0Collections": 6,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=100000, PhraseType=ExactThreeWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=ExactThreeWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactThreeWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 342181.90625,
            "medianNanoseconds": 342201.05419921875,
            "minNanoseconds": 340686.5703125,
            "maxNanoseconds": 343460.99365234375,
            "standardDeviationNanoseconds": 689.4347959450388,
            "operationsPerSecond": 2922.4222021528935
          },
          "gc": {
            "bytesAllocatedPerOperation": 378760,
            "gen0Collections": 185,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=100000, PhraseType=ExactTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=ExactTwoWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactTwoWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 406185.0657877604,
            "medianNanoseconds": 406213.080078125,
            "minNanoseconds": 405316.958984375,
            "maxNanoseconds": 407217.4833984375,
            "standardDeviationNanoseconds": 538.2824046699425,
            "operationsPerSecond": 2461.931971970923
          },
          "gc": {
            "bytesAllocatedPerOperation": 304408,
            "gen0Collections": 148,
            "gen1Collections": 37,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=100000, PhraseType=SlopTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=SlopTwoWord, DocumentCount=100000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "SlopTwoWord",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1035532.5652901785,
            "medianNanoseconds": 1035836.1787109375,
            "minNanoseconds": 1030264.55859375,
            "maxNanoseconds": 1039963.021484375,
            "standardDeviationNanoseconds": 2290.1018355733895,
            "operationsPerSecond": 965.6866751648496
          },
          "gc": {
            "bytesAllocatedPerOperation": 159344,
            "gen0Collections": 19,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "prefix",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.PrefixQueryBenchmarks-20260510-004432",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery|DocumentCount=100000, QueryPrefix=gov",
          "displayInfo": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery: DefaultJob [QueryPrefix=gov, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanLucene_PrefixQuery",
          "parameters": {
            "QueryPrefix": "gov",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 149696.74813406807,
            "medianNanoseconds": 149314.14025878906,
            "minNanoseconds": 148362.41967773438,
            "maxNanoseconds": 152860.4228515625,
            "standardDeviationNanoseconds": 1381.2435637444553,
            "operationsPerSecond": 6680.171830482264
          },
          "gc": {
            "bytesAllocatedPerOperation": 24235,
            "gen0Collections": 24,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery|DocumentCount=100000, QueryPrefix=mark",
          "displayInfo": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery: DefaultJob [QueryPrefix=mark, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanLucene_PrefixQuery",
          "parameters": {
            "QueryPrefix": "mark",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 12,
            "meanNanoseconds": 240331.1528930664,
            "medianNanoseconds": 240250.49487304688,
            "minNanoseconds": 238886.18408203125,
            "maxNanoseconds": 241688.47705078125,
            "standardDeviationNanoseconds": 925.6995197174228,
            "operationsPerSecond": 4160.925406307782
          },
          "gc": {
            "bytesAllocatedPerOperation": 35337,
            "gen0Collections": 35,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery|DocumentCount=100000, QueryPrefix=pres",
          "displayInfo": "PrefixQueryBenchmarks.LeanLucene_PrefixQuery: DefaultJob [QueryPrefix=pres, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanLucene_PrefixQuery",
          "parameters": {
            "QueryPrefix": "pres",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 290036.041922433,
            "medianNanoseconds": 290027.1071777344,
            "minNanoseconds": 283632.3125,
            "maxNanoseconds": 296767.53125,
            "standardDeviationNanoseconds": 3288.7779016924283,
            "operationsPerSecond": 3447.8473550105855
          },
          "gc": {
            "bytesAllocatedPerOperation": 64505,
            "gen0Collections": 32,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=100000, QueryPrefix=gov",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: DefaultJob [QueryPrefix=gov, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "gov",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 187265.85522460938,
            "medianNanoseconds": 187256.36596679688,
            "minNanoseconds": 186534.11474609375,
            "maxNanoseconds": 187729.62231445312,
            "standardDeviationNanoseconds": 284.34850841291296,
            "operationsPerSecond": 5340.001778757722
          },
          "gc": {
            "bytesAllocatedPerOperation": 112680,
            "gen0Collections": 110,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=100000, QueryPrefix=mark",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: DefaultJob [QueryPrefix=mark, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "mark",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 284118.53170572914,
            "medianNanoseconds": 283987.6748046875,
            "minNanoseconds": 283272.64013671875,
            "maxNanoseconds": 285244.3310546875,
            "standardDeviationNanoseconds": 664.6826325744672,
            "operationsPerSecond": 3519.657778028125
          },
          "gc": {
            "bytesAllocatedPerOperation": 129112,
            "gen0Collections": 63,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=100000, QueryPrefix=pres",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: DefaultJob [QueryPrefix=pres, DocumentCount=100000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "pres",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 355793.72626953124,
            "medianNanoseconds": 355848.01025390625,
            "minNanoseconds": 354830.87548828125,
            "maxNanoseconds": 357037.84814453125,
            "standardDeviationNanoseconds": 573.0718431891585,
            "operationsPerSecond": 2810.6172935788386
          },
          "gc": {
            "bytesAllocatedPerOperation": 136856,
            "gen0Collections": 66,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "query",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.TermQueryBenchmarks-20260510-000823",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "TermQueryBenchmarks.LeanLucene_TermQuery|DocumentCount=100000, QueryTerm=government",
          "displayInfo": "TermQueryBenchmarks.LeanLucene_TermQuery: DefaultJob [QueryTerm=government, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanLucene_TermQuery",
          "parameters": {
            "QueryTerm": "government",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 106386.88771972657,
            "medianNanoseconds": 106339.71569824219,
            "minNanoseconds": 105945.02294921875,
            "maxNanoseconds": 106776.04467773438,
            "standardDeviationNanoseconds": 220.34745020091515,
            "operationsPerSecond": 9399.654613776027
          },
          "gc": {
            "bytesAllocatedPerOperation": 480,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LeanLucene_TermQuery|DocumentCount=100000, QueryTerm=people",
          "displayInfo": "TermQueryBenchmarks.LeanLucene_TermQuery: DefaultJob [QueryTerm=people, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanLucene_TermQuery",
          "parameters": {
            "QueryTerm": "people",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 151053.68888346353,
            "medianNanoseconds": 151103.50146484375,
            "minNanoseconds": 150430.70068359375,
            "maxNanoseconds": 151570.13330078125,
            "standardDeviationNanoseconds": 331.1393687145948,
            "operationsPerSecond": 6620.162720895154
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LeanLucene_TermQuery|DocumentCount=100000, QueryTerm=said",
          "displayInfo": "TermQueryBenchmarks.LeanLucene_TermQuery: DefaultJob [QueryTerm=said, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanLucene_TermQuery",
          "parameters": {
            "QueryTerm": "said",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 687326.7730189732,
            "medianNanoseconds": 687235.88671875,
            "minNanoseconds": 685603.94921875,
            "maxNanoseconds": 689169.5146484375,
            "standardDeviationNanoseconds": 968.9489495116867,
            "operationsPerSecond": 1454.912043666886
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=100000, QueryTerm=government",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: DefaultJob [QueryTerm=government, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "government",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 135570.55552455358,
            "medianNanoseconds": 135417.39526367188,
            "minNanoseconds": 134957.78344726562,
            "maxNanoseconds": 136397.5048828125,
            "standardDeviationNanoseconds": 424.79326518932237,
            "operationsPerSecond": 7376.232959515218
          },
          "gc": {
            "bytesAllocatedPerOperation": 60896,
            "gen0Collections": 59,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=100000, QueryTerm=people",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: DefaultJob [QueryTerm=people, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "people",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 175362.4473876953,
            "medianNanoseconds": 175426.78491210938,
            "minNanoseconds": 174642.83251953125,
            "maxNanoseconds": 175859.76538085938,
            "standardDeviationNanoseconds": 363.6573128566398,
            "operationsPerSecond": 5702.475158716148
          },
          "gc": {
            "bytesAllocatedPerOperation": 58688,
            "gen0Collections": 57,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=100000, QueryTerm=said",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: DefaultJob [QueryTerm=said, DocumentCount=100000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "said",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 754172.1026041667,
            "medianNanoseconds": 754193.822265625,
            "minNanoseconds": 751818.177734375,
            "maxNanoseconds": 755734.0888671875,
            "standardDeviationNanoseconds": 1107.9550560500652,
            "operationsPerSecond": 1325.9572934970495
          },
          "gc": {
            "bytesAllocatedPerOperation": 58720,
            "gen0Collections": 14,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "schemajson",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.SchemaAndJsonBenchmarks-20260510-011359",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "SchemaAndJsonBenchmarks.LeanLucene_Index_NoSchema|DocumentCount=100000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanLucene_Index_NoSchema: DefaultJob [DocumentCount=100000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanLucene_Index_NoSchema",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10553342162.066668,
            "medianNanoseconds": 10548253141,
            "minNanoseconds": 10496021059,
            "maxNanoseconds": 10610406941,
            "standardDeviationNanoseconds": 31086604.820777755,
            "operationsPerSecond": 0.0947567116315472
          },
          "gc": {
            "bytesAllocatedPerOperation": 1252349496,
            "gen0Collections": 192,
            "gen1Collections": 82,
            "gen2Collections": 2
          }
        },
        {
          "key": "SchemaAndJsonBenchmarks.LeanLucene_Index_WithSchema|DocumentCount=100000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanLucene_Index_WithSchema: DefaultJob [DocumentCount=100000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanLucene_Index_WithSchema",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10507944163.066668,
            "medianNanoseconds": 10493052770,
            "minNanoseconds": 10461512825,
            "maxNanoseconds": 10599489578,
            "standardDeviationNanoseconds": 40499382.21038946,
            "operationsPerSecond": 0.09516609381260333
          },
          "gc": {
            "bytesAllocatedPerOperation": 1256348832,
            "gen0Collections": 193,
            "gen1Collections": 83,
            "gen2Collections": 2
          }
        },
        {
          "key": "SchemaAndJsonBenchmarks.LeanLucene_JsonMapping|DocumentCount=100000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanLucene_JsonMapping: DefaultJob [DocumentCount=100000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanLucene_JsonMapping",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 427923202.8,
            "medianNanoseconds": 428946184,
            "minNanoseconds": 424407346,
            "maxNanoseconds": 431104902,
            "standardDeviationNanoseconds": 2190002.8899398805,
            "operationsPerSecond": 2.3368679086732613
          },
          "gc": {
            "bytesAllocatedPerOperation": 226364856,
            "gen0Collections": 51,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "suggester",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.SuggesterBenchmarks-20260510-011012",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "SuggesterBenchmarks.LeanLucene_DidYouMean|DocumentCount=100000",
          "displayInfo": "SuggesterBenchmarks.LeanLucene_DidYouMean: DefaultJob [DocumentCount=100000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LeanLucene_DidYouMean",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 4635460.948918269,
            "medianNanoseconds": 4633483.265625,
            "minNanoseconds": 4615838.078125,
            "maxNanoseconds": 4672062.5703125,
            "standardDeviationNanoseconds": 14833.367147428322,
            "operationsPerSecond": 215.72827622102176
          },
          "gc": {
            "bytesAllocatedPerOperation": 25512,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SuggesterBenchmarks.LeanLucene_SpellIndex|DocumentCount=100000",
          "displayInfo": "SuggesterBenchmarks.LeanLucene_SpellIndex: DefaultJob [DocumentCount=100000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LeanLucene_SpellIndex",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 4678330.760216346,
            "medianNanoseconds": 4674481.5078125,
            "minNanoseconds": 4657409.5625,
            "maxNanoseconds": 4714285.3671875,
            "standardDeviationNanoseconds": 14905.650537692973,
            "operationsPerSecond": 213.75145351068673
          },
          "gc": {
            "bytesAllocatedPerOperation": 23752,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SuggesterBenchmarks.LuceneNet_SpellChecker|DocumentCount=100000",
          "displayInfo": "SuggesterBenchmarks.LuceneNet_SpellChecker: DefaultJob [DocumentCount=100000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LuceneNet_SpellChecker",
          "parameters": {
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10254258.8125,
            "medianNanoseconds": 10243670.265625,
            "minNanoseconds": 10210806.390625,
            "maxNanoseconds": 10302941.90625,
            "standardDeviationNanoseconds": 27980.293217647217,
            "operationsPerSecond": 97.52045645473608
          },
          "gc": {
            "bytesAllocatedPerOperation": 5479576,
            "gen0Collections": 83,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "wildcard",
      "summaryTitle": "Rowles.LeanLucene.Benchmarks.WildcardQueryBenchmarks-20260510-005513",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery|DocumentCount=100000, WildcardPattern=gov*",
          "displayInfo": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery: DefaultJob [WildcardPattern=gov*, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanLucene_WildcardQuery",
          "parameters": {
            "WildcardPattern": "gov*",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 150152.8491398738,
            "medianNanoseconds": 150310.36328125,
            "minNanoseconds": 148443.60717773438,
            "maxNanoseconds": 151169.0830078125,
            "standardDeviationNanoseconds": 670.7444450647262,
            "operationsPerSecond": 6659.8802868432895
          },
          "gc": {
            "bytesAllocatedPerOperation": 24960,
            "gen0Collections": 25,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery|DocumentCount=100000, WildcardPattern=m*rket",
          "displayInfo": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery: DefaultJob [WildcardPattern=m*rket, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanLucene_WildcardQuery",
          "parameters": {
            "WildcardPattern": "m*rket",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 18,
            "meanNanoseconds": 528970.8275282118,
            "medianNanoseconds": 534184.2055664062,
            "minNanoseconds": 505804.615234375,
            "maxNanoseconds": 542294.048828125,
            "standardDeviationNanoseconds": 11229.16944419407,
            "operationsPerSecond": 1890.463420587531
          },
          "gc": {
            "bytesAllocatedPerOperation": 10419,
            "gen0Collections": 2,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery|DocumentCount=100000, WildcardPattern=pre*dent",
          "displayInfo": "WildcardQueryBenchmarks.LeanLucene_WildcardQuery: DefaultJob [WildcardPattern=pre*dent, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanLucene_WildcardQuery",
          "parameters": {
            "WildcardPattern": "pre*dent",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 106486.87327473958,
            "medianNanoseconds": 106362.04650878906,
            "minNanoseconds": 105246.6708984375,
            "maxNanoseconds": 107759.11877441406,
            "standardDeviationNanoseconds": 754.8929493387212,
            "operationsPerSecond": 9390.828834085189
          },
          "gc": {
            "bytesAllocatedPerOperation": 8832,
            "gen0Collections": 17,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=100000, WildcardPattern=gov*",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: DefaultJob [WildcardPattern=gov*, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "gov*",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 202033.19013323102,
            "medianNanoseconds": 201896.30053710938,
            "minNanoseconds": 201452.87646484375,
            "maxNanoseconds": 202750.4072265625,
            "standardDeviationNanoseconds": 350.08045774291253,
            "operationsPerSecond": 4949.68177921929
          },
          "gc": {
            "bytesAllocatedPerOperation": 132160,
            "gen0Collections": 129,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=100000, WildcardPattern=m*rket",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: DefaultJob [WildcardPattern=m*rket, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "m*rket",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1167828.0980747768,
            "medianNanoseconds": 1167547.3916015625,
            "minNanoseconds": 1161447.29296875,
            "maxNanoseconds": 1173018.453125,
            "standardDeviationNanoseconds": 2924.1499811793115,
            "operationsPerSecond": 856.2904092208007
          },
          "gc": {
            "bytesAllocatedPerOperation": 414224,
            "gen0Collections": 50,
            "gen1Collections": 5,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=100000, WildcardPattern=pre*dent",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: DefaultJob [WildcardPattern=pre*dent, DocumentCount=100000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "pre*dent",
            "DocumentCount": "100000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 410527.88990885415,
            "medianNanoseconds": 410419.06103515625,
            "minNanoseconds": 408905.93408203125,
            "maxNanoseconds": 412759.71533203125,
            "standardDeviationNanoseconds": 1000.4989289832179,
            "operationsPerSecond": 2435.8880957442893
          },
          "gc": {
            "bytesAllocatedPerOperation": 388608,
            "gen0Collections": 190,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    }
  ]
}</code></pre>

</details>

