---
title: Benchmarks - debian
---

# Benchmarks: debian

**.NET** 10.0.3 &nbsp;&middot;&nbsp; **Commit** `3e35ed5` &nbsp;&middot;&nbsp; 22 May 2026 13:26 UTC &nbsp;&middot;&nbsp; 222 benchmarks

## aggregation

| Method                                 | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|---------:|--------:|------:|-------:|----------:|------------:|
| LeanCorpus_SearchOnly                  | DefaultJob | Default        | Default     | Default     | 1000          | 306.4 ns |  0.61 ns | 0.57 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithStats             | DefaultJob | Default        | Default     | Default     | 1000          | 341.1 ns |  2.36 ns | 2.09 ns |  1.11 | 0.0687 |     288 B |        1.12 |
| LeanCorpus_SearchWithHistogram         | DefaultJob | Default        | Default     | Default     | 1000          | 359.8 ns |  3.37 ns | 3.16 ns |  1.17 | 0.0687 |     288 B |        1.12 |
| LeanCorpus_SearchWithStatsAndHistogram | DefaultJob | Default        | Default     | Default     | 1000          | 317.9 ns |  0.66 ns | 0.62 ns |  1.04 | 0.0706 |     296 B |        1.16 |
|                                        |            |                |             |             |               |          |          |         |       |        |           |             |
| LeanCorpus_SearchOnly                  | ShortRun   | 3              | 1           | 3           | 1000          | 309.3 ns | 11.52 ns | 0.63 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithStats             | ShortRun   | 3              | 1           | 3           | 1000          | 344.9 ns |  2.75 ns | 0.15 ns |  1.12 | 0.0687 |     288 B |        1.12 |
| LeanCorpus_SearchWithHistogram         | ShortRun   | 3              | 1           | 3           | 1000          | 345.7 ns | 18.41 ns | 1.01 ns |  1.12 | 0.0687 |     288 B |        1.12 |
| LeanCorpus_SearchWithStatsAndHistogram | ShortRun   | 3              | 1           | 3           | 1000          | 362.2 ns |  5.47 ns | 0.30 ns |  1.17 | 0.0706 |     296 B |        1.16 |

## Analysis

| Method             | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0     | Allocated  | Alloc Ratio |
|------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|----------:|----------:|------:|---------:|-----------:|------------:|
| LeanCorpus_Analyse | DefaultJob | Default        | Default     | Default     | 1000          | 4.141 ms | 0.0159 ms | 0.0148 ms |  1.00 |   7.8125 |   45.31 KB |        1.00 |
| LuceneNet_Analyse  | DefaultJob | Default        | Default     | Default     | 1000          | 6.311 ms | 0.0188 ms | 0.0166 ms |  1.52 | 406.2500 | 1660.61 KB |       36.65 |
|                    |            |                |             |             |               |          |           |           |       |          |            |             |
| LeanCorpus_Analyse | ShortRun   | 3              | 1           | 3           | 1000          | 4.131 ms | 0.5073 ms | 0.0278 ms |  1.00 |   7.8125 |   45.31 KB |        1.00 |
| LuceneNet_Analyse  | ShortRun   | 3              | 1           | 3           | 1000          | 6.424 ms | 0.3763 ms | 0.0206 ms |  1.56 | 406.2500 | 1660.61 KB |       36.65 |

## analysis-filters

| Method | Job        | IterationCount | LaunchCount | WarmupCount | Scenario             | Mean     | Error    | StdDev  | Gen0   | Allocated |
|------- |----------- |--------------- |------------ |------------ |--------------------- |---------:|---------:|--------:|-------:|----------:|
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **decim(...)ating [22]** | **153.9 ns** |  **0.29 ns** | **0.27 ns** | **0.0401** |     **168 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | decim(...)ating [22] | 155.2 ns |  8.14 ns | 0.45 ns | 0.0401 |     168 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **elision-mutating**     | **213.8 ns** |  **0.47 ns** | **0.40 ns** | **0.0477** |     **200 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | elision-mutating     | 214.8 ns |  7.50 ns | 0.41 ns | 0.0477 |     200 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **length-mutating**      | **121.6 ns** |  **0.27 ns** | **0.26 ns** | **0.0420** |     **176 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | length-mutating      | 120.9 ns |  3.75 ns | 0.21 ns | 0.0420 |     176 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **length-noop**          | **103.1 ns** |  **0.19 ns** | **0.18 ns** | **0.0421** |     **176 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | length-noop          | 103.7 ns |  5.35 ns | 0.29 ns | 0.0421 |     176 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **reverse-mutating**     | **140.2 ns** |  **0.29 ns** | **0.27 ns** | **0.0496** |     **208 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | reverse-mutating     | 139.0 ns |  3.04 ns | 0.17 ns | 0.0496 |     208 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **shingle-mutating**     | **392.3 ns** |  **0.50 ns** | **0.44 ns** | **0.2065** |     **864 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | shingle-mutating     | 401.7 ns | 12.80 ns | 0.70 ns | 0.2065 |     864 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **truncate-mutating**    | **117.2 ns** |  **0.16 ns** | **0.15 ns** | **0.0421** |     **176 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | truncate-mutating    | 116.3 ns |  9.11 ns | 0.50 ns | 0.0421 |     176 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **truncate-noop**        | **103.4 ns** |  **0.21 ns** | **0.20 ns** | **0.0421** |     **176 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | truncate-noop        | 102.1 ns |  6.08 ns | 0.33 ns | 0.0421 |     176 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **unique-mutating**      | **222.4 ns** |  **0.48 ns** | **0.44 ns** | **0.0937** |     **392 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | unique-mutating      | 223.0 ns | 12.81 ns | 0.70 ns | 0.0937 |     392 B |
| **Apply**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **word-(...)ating [23]** | **592.7 ns** |  **1.21 ns** | **1.13 ns** | **0.3424** |    **1432 B** |
| Apply  | ShortRun   | 3              | 1           | 3           | word-(...)ating [23] | 586.9 ns | 26.24 ns | 1.44 ns | 0.3424 |    1432 B |

## analysis-parity

| Method                | Job        | IterationCount | LaunchCount | WarmupCount | Mean      | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------- |----------- |--------------- |------------ |------------ |----------:|----------:|----------:|------:|-------:|----------:|------------:|
| LeanCorpus_Whitespace | DefaultJob | Default        | Default     | Default     | 48.282 μs | 0.0520 μs | 0.0461 μs |  1.00 |      - |         - |          NA |
| LuceneNet_Whitespace  | DefaultJob | Default        | Default     | Default     | 74.324 μs | 0.2177 μs | 0.1930 μs |  1.54 | 0.7324 |    3200 B |          NA |
| LeanCorpus_Keyword    | DefaultJob | Default        | Default     | Default     |  4.094 μs | 0.0053 μs | 0.0050 μs |  0.08 |      - |         - |          NA |
| LuceneNet_Keyword     | DefaultJob | Default        | Default     | Default     | 11.951 μs | 0.0174 μs | 0.0163 μs |  0.25 | 0.7629 |    3200 B |          NA |
| LeanCorpus_Simple     | DefaultJob | Default        | Default     | Default     | 41.959 μs | 0.0588 μs | 0.0550 μs |  0.87 |      - |         - |          NA |
| LuceneNet_Simple      | DefaultJob | Default        | Default     | Default     | 81.993 μs | 0.1202 μs | 0.1065 μs |  1.70 | 0.7324 |    3200 B |          NA |
|                       |            |                |             |             |           |           |           |       |        |           |             |
| LeanCorpus_Whitespace | ShortRun   | 3              | 1           | 3           | 48.106 μs | 1.0071 μs | 0.0552 μs |  1.00 |      - |         - |          NA |
| LuceneNet_Whitespace  | ShortRun   | 3              | 1           | 3           | 73.619 μs | 1.9096 μs | 0.1047 μs |  1.53 | 0.7324 |    3200 B |          NA |
| LeanCorpus_Keyword    | ShortRun   | 3              | 1           | 3           |  4.207 μs | 0.1506 μs | 0.0083 μs |  0.09 |      - |         - |          NA |
| LuceneNet_Keyword     | ShortRun   | 3              | 1           | 3           | 12.198 μs | 0.2700 μs | 0.0148 μs |  0.25 | 0.7629 |    3200 B |          NA |
| LeanCorpus_Simple     | ShortRun   | 3              | 1           | 3           | 41.885 μs | 0.8364 μs | 0.0458 μs |  0.87 |      - |         - |          NA |
| LuceneNet_Simple      | ShortRun   | 3              | 1           | 3           | 82.158 μs | 1.8280 μs | 0.1002 μs |  1.71 | 0.7324 |    3200 B |          NA |

## async-index

| Method                                 | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error    | StdDev   | Ratio | Gen0     | Gen1     | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|---------:|---------:|------:|---------:|---------:|----------:|------------:|
| LeanCorpus_AddDocument_Sync            | DefaultJob | Default        | Default     | Default     | 1000          | 36.50 ms | 0.285 ms | 0.252 ms |  1.00 | 928.5714 | 428.5714 |   7.72 MB |        1.00 |
| LeanCorpus_AddDocumentAsync_Sequential | DefaultJob | Default        | Default     | Default     | 1000          | 36.16 ms | 0.174 ms | 0.163 ms |  0.99 | 928.5714 | 428.5714 |   7.74 MB |        1.00 |
| LeanCorpus_AddDocumentsAsync_Batch     | DefaultJob | Default        | Default     | Default     | 1000          | 36.10 ms | 0.111 ms | 0.093 ms |  0.99 | 928.5714 | 428.5714 |   7.74 MB |        1.00 |
|                                        |            |                |             |             |               |          |          |          |       |          |          |           |             |
| LeanCorpus_AddDocument_Sync            | ShortRun   | 3              | 1           | 3           | 1000          | 36.25 ms | 6.334 ms | 0.347 ms |  1.00 | 928.5714 | 428.5714 |   7.72 MB |        1.00 |
| LeanCorpus_AddDocumentAsync_Sequential | ShortRun   | 3              | 1           | 3           | 1000          | 36.32 ms | 1.053 ms | 0.058 ms |  1.00 | 928.5714 | 428.5714 |   7.74 MB |        1.00 |
| LeanCorpus_AddDocumentsAsync_Batch     | ShortRun   | 3              | 1           | 3           | 1000          | 36.27 ms | 2.652 ms | 0.145 ms |  1.00 | 928.5714 | 428.5714 |   7.74 MB |        1.00 |

## Block-Join (index)

| Method                 | Job        | IterationCount | LaunchCount | WarmupCount | BlockCount | Mean     | Error    | StdDev  | Ratio | RatioSD | Gen0      | Gen1      | Allocated | Alloc Ratio |
|----------------------- |----------- |--------------- |------------ |------------ |----------- |---------:|---------:|--------:|------:|--------:|----------:|----------:|----------:|------------:|
| LeanLucene_IndexBlocks | Job-CNUJVU | Default        | Default     | Default     | 1000       | 111.7 ms |  2.19 ms | 2.92 ms |  1.00 |    0.00 | 2000.0000 | 1000.0000 |  19.27 MB |        1.00 |
| LuceneNet_IndexBlocks  | Job-CNUJVU | Default        | Default     | Default     | 1000       | 102.5 ms |  0.88 ms | 0.78 ms |  0.92 |    0.02 | 8000.0000 | 2000.0000 |  44.06 MB |        2.29 |
|                        |            |                |             |             |            |          |          |         |       |         |           |           |           |             |
| LeanLucene_IndexBlocks | ShortRun   | 3              | 1           | 3           | 1000       | 113.4 ms | 51.00 ms | 2.80 ms |  1.00 |    0.00 | 2000.0000 | 1000.0000 |  19.27 MB |        1.00 |
| LuceneNet_IndexBlocks  | ShortRun   | 3              | 1           | 3           | 1000       | 103.1 ms | 15.79 ms | 0.87 ms |  0.91 |    0.02 | 8000.0000 | 2000.0000 |  44.06 MB |        2.29 |

## Block-Join (search)

| Method                           | Job        | IterationCount | LaunchCount | WarmupCount | BlockCount | Mean     | Error    | StdDev   | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------------- |----------- |--------------- |------------ |------------ |----------- |---------:|---------:|---------:|------:|-------:|-------:|----------:|------------:|
| LeanLucene_BlockJoinQuery        | DefaultJob | Default        | Default     | Default     | 1000       | 10.26 μs | 0.024 μs | 0.023 μs |  1.00 | 0.1678 |      - |     720 B |        1.00 |
| LuceneNet_ToParentBlockJoinQuery | DefaultJob | Default        | Default     | Default     | 1000       | 32.26 μs | 0.109 μs | 0.102 μs |  3.14 | 2.6245 | 0.0610 |   11118 B |       15.44 |
|                                  |            |                |             |             |            |          |          |          |       |        |        |           |             |
| LeanLucene_BlockJoinQuery        | ShortRun   | 3              | 1           | 3           | 1000       | 10.32 μs | 0.387 μs | 0.021 μs |  1.00 | 0.1678 |      - |     720 B |        1.00 |
| LuceneNet_ToParentBlockJoinQuery | ShortRun   | 3              | 1           | 3           | 1000       | 32.06 μs | 2.598 μs | 0.142 μs |  3.11 | 2.6245 | 0.0610 |   11118 B |       15.44 |

## Boolean queries

| Method                  | Job        | IterationCount | LaunchCount | WarmupCount | BooleanShape  | DocumentCount | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------ |----------- |--------------- |------------ |------------ |-------------- |-------------- |----------:|----------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_BooleanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Must2Common**   | **1000**          |  **1.423 μs** | **0.0025 μs** | **0.0021 μs** |  **1.00** |    **0.00** |  **0.3242** |      **-** |   **1.33 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | DefaultJob | Default        | Default     | Default     | Must2Common   | 1000          | 10.508 μs | 0.1244 μs | 0.1164 μs |  7.39 |    0.08 |  3.3112 | 0.0305 |  13.66 KB |       10.29 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| LeanCorpus_BooleanQuery | ShortRun   | 3              | 1           | 3           | Must2Common   | 1000          |  1.362 μs | 0.0757 μs | 0.0041 μs |  1.00 |    0.00 |  0.3242 |      - |   1.33 KB |        1.00 |
| LuceneNet_BooleanQuery  | ShortRun   | 3              | 1           | 3           | Must2Common   | 1000          | 10.587 μs | 1.2732 μs | 0.0698 μs |  7.77 |    0.05 |  3.3112 | 0.0305 |  13.66 KB |       10.29 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| **LeanCorpus_BooleanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Must3Mixed**    | **1000**          |  **1.850 μs** | **0.0039 μs** | **0.0036 μs** |  **1.00** |    **0.00** |  **0.3796** |      **-** |   **1.55 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | DefaultJob | Default        | Default     | Default     | Must3Mixed    | 1000          | 15.471 μs | 0.2679 μs | 0.2506 μs |  8.36 |    0.13 |  4.7302 | 0.0305 |  19.53 KB |       12.56 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| LeanCorpus_BooleanQuery | ShortRun   | 3              | 1           | 3           | Must3Mixed    | 1000          |  1.810 μs | 0.0498 μs | 0.0027 μs |  1.00 |    0.00 |  0.3796 |      - |   1.55 KB |        1.00 |
| LuceneNet_BooleanQuery  | ShortRun   | 3              | 1           | 3           | Must3Mixed    | 1000          | 19.712 μs | 0.4881 μs | 0.0268 μs | 10.89 |    0.02 |  4.7455 | 0.0305 |  19.53 KB |       12.56 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| **LeanCorpus_BooleanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **MustNotCommon** | **1000**          |  **1.197 μs** | **0.0029 μs** | **0.0027 μs** |  **1.00** |    **0.00** |  **0.3223** |      **-** |   **1.32 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | DefaultJob | Default        | Default     | Default     | MustNotCommon | 1000          | 10.736 μs | 0.1999 μs | 0.1963 μs |  8.97 |    0.16 |  3.2349 | 0.0305 |  13.35 KB |       10.11 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| LeanCorpus_BooleanQuery | ShortRun   | 3              | 1           | 3           | MustNotCommon | 1000          |  1.282 μs | 0.1150 μs | 0.0063 μs |  1.00 |    0.00 |  0.3223 |      - |   1.32 KB |        1.00 |
| LuceneNet_BooleanQuery  | ShortRun   | 3              | 1           | 3           | MustNotCommon | 1000          | 10.683 μs | 0.0584 μs | 0.0032 μs |  8.33 |    0.04 |  3.2349 | 0.0305 |  13.35 KB |       10.11 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| **LeanCorpus_BooleanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Should2Common** | **1000**          |  **2.230 μs** | **0.0053 μs** | **0.0044 μs** |  **1.00** |    **0.00** |  **0.3662** |      **-** |    **1.5 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | DefaultJob | Default        | Default     | Default     | Should2Common | 1000          | 51.665 μs | 0.1572 μs | 0.1470 μs | 23.16 |    0.08 | 31.5552 | 0.3662 | 129.33 KB |       86.22 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| LeanCorpus_BooleanQuery | ShortRun   | 3              | 1           | 3           | Should2Common | 1000          |  2.343 μs | 0.1048 μs | 0.0057 μs |  1.00 |    0.00 |  0.3662 |      - |    1.5 KB |        1.00 |
| LuceneNet_BooleanQuery  | ShortRun   | 3              | 1           | 3           | Should2Common | 1000          | 51.576 μs | 1.8549 μs | 0.1017 μs | 22.01 |    0.06 | 31.5552 | 0.3662 | 129.33 KB |       86.22 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| **LeanCorpus_BooleanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Should4Mixed**  | **1000**          |  **3.309 μs** | **0.0109 μs** | **0.0102 μs** |  **1.00** |    **0.00** |  **0.5112** |      **-** |   **2.09 KB** |        **1.00** |
| LuceneNet_BooleanQuery  | DefaultJob | Default        | Default     | Default     | Should4Mixed  | 1000          | 73.846 μs | 0.1958 μs | 0.1832 μs | 22.31 |    0.09 | 34.1797 | 0.4272 | 141.39 KB |       67.53 |
|                         |            |                |             |             |               |               |           |           |           |       |         |         |        |           |             |
| LeanCorpus_BooleanQuery | ShortRun   | 3              | 1           | 3           | Should4Mixed  | 1000          |  3.362 μs | 0.0922 μs | 0.0051 μs |  1.00 |    0.00 |  0.5112 |      - |   2.09 KB |        1.00 |
| LuceneNet_BooleanQuery  | ShortRun   | 3              | 1           | 3           | Should4Mixed  | 1000          | 72.515 μs | 5.5480 μs | 0.3041 μs | 21.57 |    0.08 | 34.1797 | 0.4272 | 141.39 KB |       67.53 |

## collapse-facet

| Method                                 | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|---------:|--------:|------:|-------:|----------:|------------:|
| LeanCorpus_BaseSearch                  | DefaultJob | Default        | Default     | Default     | 1000          | 308.5 ns |  0.79 ns | 0.70 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithCollapse          | DefaultJob | Default        | Default     | Default     | 1000          | 307.6 ns |  0.58 ns | 0.54 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithFacets            | DefaultJob | Default        | Default     | Default     | 1000          | 408.9 ns |  0.83 ns | 0.78 ns |  1.33 | 0.1087 |     456 B |        1.78 |
| LeanCorpus_SearchWithCollapseAndFacets | DefaultJob | Default        | Default     | Default     | 1000          | 307.3 ns |  1.18 ns | 1.10 ns |  1.00 | 0.0610 |     256 B |        1.00 |
|                                        |            |                |             |             |               |          |          |         |       |        |           |             |
| LeanCorpus_BaseSearch                  | ShortRun   | 3              | 1           | 3           | 1000          | 309.7 ns |  6.41 ns | 0.35 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithCollapse          | ShortRun   | 3              | 1           | 3           | 1000          | 308.7 ns | 28.82 ns | 1.58 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearchWithFacets            | ShortRun   | 3              | 1           | 3           | 1000          | 368.3 ns | 19.98 ns | 1.10 ns |  1.19 | 0.1087 |     456 B |        1.78 |
| LeanCorpus_SearchWithCollapseAndFacets | ShortRun   | 3              | 1           | 3           | 1000          | 309.9 ns | 10.40 ns | 0.57 ns |  1.00 | 0.0610 |     256 B |        1.00 |

## combined

| Method                             | Job        | IterationCount | LaunchCount | WarmupCount | MinimumShouldMatch | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |----------- |--------------- |------------ |------------ |------------------- |-------------- |---------:|----------:|----------:|------:|-------:|----------:|------------:|
| **LeanCorpus_CombinedFieldsQuery**     | **DefaultJob** | **Default**        | **Default**     | **Default**     | **1**                  | **1000**          | **3.112 μs** | **0.0102 μs** | **0.0086 μs** |  **1.00** | **0.7706** |   **3.16 KB** |        **1.00** |
| LeanCorpus_BooleanQuery_MultiField | DefaultJob | Default        | Default     | Default     | 1                  | 1000          | 2.577 μs | 0.0096 μs | 0.0090 μs |  0.83 | 0.6447 |   2.64 KB |        0.84 |
|                                    |            |                |             |             |                    |               |          |           |           |       |        |           |             |
| LeanCorpus_CombinedFieldsQuery     | ShortRun   | 3              | 1           | 3           | 1                  | 1000          | 3.065 μs | 0.0866 μs | 0.0047 μs |  1.00 | 0.7706 |   3.16 KB |        1.00 |
| LeanCorpus_BooleanQuery_MultiField | ShortRun   | 3              | 1           | 3           | 1                  | 1000          | 2.430 μs | 0.0653 μs | 0.0036 μs |  0.79 | 0.6447 |   2.64 KB |        0.84 |
|                                    |            |                |             |             |                    |               |          |           |           |       |        |           |             |
| **LeanCorpus_CombinedFieldsQuery**     | **DefaultJob** | **Default**        | **Default**     | **Default**     | **2**                  | **1000**          | **3.240 μs** | **0.0074 μs** | **0.0069 μs** |  **1.00** | **0.7706** |   **3.16 KB** |        **1.00** |
| LeanCorpus_BooleanQuery_MultiField | DefaultJob | Default        | Default     | Default     | 2                  | 1000          | 2.518 μs | 0.0064 μs | 0.0056 μs |  0.78 | 0.6447 |   2.64 KB |        0.84 |
|                                    |            |                |             |             |                    |               |          |           |           |       |        |           |             |
| LeanCorpus_CombinedFieldsQuery     | ShortRun   | 3              | 1           | 3           | 2                  | 1000          | 3.205 μs | 0.3084 μs | 0.0169 μs |  1.00 | 0.7706 |   3.16 KB |        1.00 |
| LeanCorpus_BooleanQuery_MultiField | ShortRun   | 3              | 1           | 3           | 2                  | 1000          | 2.479 μs | 0.0298 μs | 0.0016 μs |  0.77 | 0.6447 |   2.64 KB |        0.84 |

## Deletion (commit)

| Method                   | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean       | Error       | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |----------- |--------------- |------------ |------------ |-------------- |-----------:|------------:|---------:|------:|--------:|----------:|------------:|
| LeanLucene_CommitDeletes | Job-CNUJVU | Default        | Default     | Default     | 1000          | 1,226.9 μs |    18.67 μs | 15.59 μs |  1.00 |    0.00 | 271.49 KB |        1.00 |
| LuceneNet_CommitDeletes  | Job-CNUJVU | Default        | Default     | Default     | 1000          |   704.7 μs |    22.60 μs | 66.29 μs |  0.57 |    0.05 | 345.63 KB |        1.27 |
|                          |            |                |             |             |               |            |             |          |       |         |           |             |
| LeanLucene_CommitDeletes | ShortRun   | 3              | 1           | 3           | 1000          | 1,220.2 μs |   559.93 μs | 30.69 μs |  1.00 |    0.00 | 271.49 KB |        1.00 |
| LuceneNet_CommitDeletes  | ShortRun   | 3              | 1           | 3           | 1000          |   869.1 μs | 1,015.50 μs | 55.66 μs |  0.71 |    0.04 | 346.55 KB |        1.28 |

## Deletion (queue)

| Method                  | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean      | Error      | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------ |----------- |--------------- |------------ |------------ |-------------- |----------:|-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LeanLucene_QueueDeletes | Job-CNUJVU | Default        | Default     | Default     | 1000          |  6.827 μs |  0.3333 μs | 0.9123 μs |  6.531 μs |  1.00 |    0.00 |  10.73 KB |        1.00 |
| LuceneNet_QueueDeletes  | Job-CNUJVU | Default        | Default     | Default     | 1000          | 38.434 μs |  1.4273 μs | 4.0022 μs | 36.901 μs |  5.72 |    0.88 |   25.5 KB |        2.38 |
|                         |            |                |             |             |               |           |            |           |           |       |         |           |             |
| LeanLucene_QueueDeletes | ShortRun   | 3              | 1           | 3           | 1000          | 15.579 μs | 52.4742 μs | 2.8763 μs | 13.998 μs |  1.00 |    0.00 |  10.73 KB |        1.00 |
| LuceneNet_QueueDeletes  | ShortRun   | 3              | 1           | 3           | 1000          | 66.411 μs |  8.8877 μs | 0.4872 μs | 66.276 μs |  4.35 |    0.63 |   25.5 KB |        2.38 |

## dismax

| Method                         | Job        | IterationCount | LaunchCount | WarmupCount | TieBreakerMultiplier | DocumentCount | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------- |----------- |--------------- |------------ |------------ |--------------------- |-------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_DisjunctionMaxQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0**                    | **1000**          |  **2.776 μs** | **0.0041 μs** | **0.0034 μs** |  **1.00** |    **0.00** | **0.3548** |   **1.45 KB** |        **1.00** |
| LuceneNet_DisjunctionMaxQuery  | DefaultJob | Default        | Default     | Default     | 0                    | 1000          | 14.049 μs | 0.0308 μs | 0.0288 μs |  5.06 |    0.01 | 6.7444 |  27.57 KB |       18.97 |
|                                |            |                |             |             |                      |               |           |           |           |       |         |        |           |             |
| LeanCorpus_DisjunctionMaxQuery | ShortRun   | 3              | 1           | 3           | 0                    | 1000          |  2.747 μs | 0.1071 μs | 0.0059 μs |  1.00 |    0.00 | 0.3548 |   1.45 KB |        1.00 |
| LuceneNet_DisjunctionMaxQuery  | ShortRun   | 3              | 1           | 3           | 0                    | 1000          | 14.386 μs | 0.9541 μs | 0.0523 μs |  5.24 |    0.02 | 6.7444 |  27.57 KB |       18.97 |
|                                |            |                |             |             |                      |               |           |           |           |       |         |        |           |             |
| **LeanCorpus_DisjunctionMaxQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0.1**                  | **1000**          |  **2.770 μs** | **0.0059 μs** | **0.0055 μs** |  **1.00** |    **0.00** | **0.3548** |   **1.45 KB** |        **1.00** |
| LuceneNet_DisjunctionMaxQuery  | DefaultJob | Default        | Default     | Default     | 0.1                  | 1000          | 14.799 μs | 0.0517 μs | 0.0484 μs |  5.34 |    0.02 | 6.7444 |  27.57 KB |       18.97 |
|                                |            |                |             |             |                      |               |           |           |           |       |         |        |           |             |
| LeanCorpus_DisjunctionMaxQuery | ShortRun   | 3              | 1           | 3           | 0.1                  | 1000          |  2.733 μs | 0.1141 μs | 0.0063 μs |  1.00 |    0.00 | 0.3548 |   1.45 KB |        1.00 |
| LuceneNet_DisjunctionMaxQuery  | ShortRun   | 3              | 1           | 3           | 0.1                  | 1000          | 13.986 μs | 0.7802 μs | 0.0428 μs |  5.12 |    0.02 | 6.7444 |  27.57 KB |       18.97 |
|                                |            |                |             |             |                      |               |           |           |           |       |         |        |           |             |
| **LeanCorpus_DisjunctionMaxQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0.5**                  | **1000**          |  **2.800 μs** | **0.0071 μs** | **0.0066 μs** |  **1.00** |    **0.00** | **0.3548** |   **1.45 KB** |        **1.00** |
| LuceneNet_DisjunctionMaxQuery  | DefaultJob | Default        | Default     | Default     | 0.5                  | 1000          | 14.286 μs | 0.0196 μs | 0.0183 μs |  5.10 |    0.01 | 6.7444 |  27.57 KB |       18.97 |
|                                |            |                |             |             |                      |               |           |           |           |       |         |        |           |             |
| LeanCorpus_DisjunctionMaxQuery | ShortRun   | 3              | 1           | 3           | 0.5                  | 1000          |  2.776 μs | 0.0948 μs | 0.0052 μs |  1.00 |    0.00 | 0.3548 |   1.45 KB |        1.00 |
| LuceneNet_DisjunctionMaxQuery  | ShortRun   | 3              | 1           | 3           | 0.5                  | 1000          | 14.302 μs | 0.2871 μs | 0.0157 μs |  5.15 |    0.01 | 6.7444 |  27.57 KB |       18.97 |

## function-score

| Method                        | Job        | IterationCount | LaunchCount | WarmupCount | Mode     | DocumentCount | Mean       | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |----------- |--------------- |------------ |------------ |--------- |-------------- |-----------:|---------:|--------:|------:|-------:|----------:|------------:|
| **LeanCorpus_BaseTermQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Max**      | **1000**          |   **304.1 ns** |  **0.60 ns** | **0.56 ns** |  **1.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_FunctionScoreQuery | DefaultJob | Default        | Default     | Default     | Max      | 1000          |   967.3 ns |  1.34 ns | 1.12 ns |  3.18 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| LeanCorpus_BaseTermQuery      | ShortRun   | 3              | 1           | 3           | Max      | 1000          |   306.1 ns | 11.18 ns | 0.61 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_FunctionScoreQuery | ShortRun   | 3              | 1           | 3           | Max      | 1000          |   969.6 ns | 47.50 ns | 2.60 ns |  3.17 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| **LeanCorpus_BaseTermQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Multiply** | **1000**          |   **308.7 ns** |  **0.68 ns** | **0.64 ns** |  **1.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_FunctionScoreQuery | DefaultJob | Default        | Default     | Default     | Multiply | 1000          |   968.1 ns |  3.55 ns | 3.15 ns |  3.14 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| LeanCorpus_BaseTermQuery      | ShortRun   | 3              | 1           | 3           | Multiply | 1000          |   308.5 ns | 13.74 ns | 0.75 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_FunctionScoreQuery | ShortRun   | 3              | 1           | 3           | Multiply | 1000          |   960.3 ns | 70.72 ns | 3.88 ns |  3.11 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| **LeanCorpus_BaseTermQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Replace**  | **1000**          |   **313.9 ns** |  **0.46 ns** | **0.39 ns** |  **1.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_FunctionScoreQuery | DefaultJob | Default        | Default     | Default     | Replace  | 1000          | 1,038.8 ns |  4.41 ns | 4.13 ns |  3.31 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| LeanCorpus_BaseTermQuery      | ShortRun   | 3              | 1           | 3           | Replace  | 1000          |   303.1 ns | 13.02 ns | 0.71 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_FunctionScoreQuery | ShortRun   | 3              | 1           | 3           | Replace  | 1000          |   961.9 ns | 46.35 ns | 2.54 ns |  3.17 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| **LeanCorpus_BaseTermQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Sum**      | **1000**          |   **303.4 ns** |  **0.55 ns** | **0.52 ns** |  **1.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_FunctionScoreQuery | DefaultJob | Default        | Default     | Default     | Sum      | 1000          |   965.4 ns |  1.82 ns | 1.61 ns |  3.18 | 2.0638 |    8624 B |       33.69 |
|                               |            |                |             |             |          |               |            |          |         |       |        |           |             |
| LeanCorpus_BaseTermQuery      | ShortRun   | 3              | 1           | 3           | Sum      | 1000          |   314.2 ns | 17.61 ns | 0.97 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_FunctionScoreQuery | ShortRun   | 3              | 1           | 3           | Sum      | 1000          |   966.1 ns | 61.62 ns | 3.38 ns |  3.07 | 2.0638 |    8624 B |       33.69 |

## Fuzzy queries

| Method                | Job        | IterationCount | LaunchCount | WarmupCount | Scenario            | DocumentCount | Mean           | Error         | StdDev      | Ratio    | RatioSD | Gen0     | Gen1     | Allocated | Alloc Ratio |
|---------------------- |----------- |--------------- |------------ |------------ |-------------------- |-------------- |---------------:|--------------:|------------:|---------:|--------:|---------:|---------:|----------:|------------:|
| **LeanCorpus_FuzzyQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **long-edit1-common**   | **1000**          |       **207.5 ns** |       **0.57 ns** |     **0.53 ns** |     **1.00** |    **0.00** |   **0.1070** |        **-** |     **448 B** |        **1.00** |
| LuceneNet_FuzzyQuery  | DefaultJob | Default        | Default     | Default     | long-edit1-common   | 1000          |   211,766.6 ns |     333.51 ns |   311.96 ns | 1,020.57 |    2.91 |  78.8574 |   2.6855 |  330291 B |      737.26 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| LeanCorpus_FuzzyQuery | ShortRun   | 3              | 1           | 3           | long-edit1-common   | 1000          |       206.2 ns |       9.01 ns |     0.49 ns |     1.00 |    0.00 |   0.1070 |        - |     448 B |        1.00 |
| LuceneNet_FuzzyQuery  | ShortRun   | 3              | 1           | 3           | long-edit1-common   | 1000          |   211,854.8 ns |   8,373.38 ns |   458.97 ns | 1,027.52 |    2.87 |  78.8574 |   2.6855 |  330291 B |      737.26 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| **LeanCorpus_FuzzyQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **medium-edit1-common** | **1000**          |       **211.2 ns** |       **0.72 ns** |     **0.68 ns** |     **1.00** |    **0.00** |   **0.1070** |        **-** |     **448 B** |        **1.00** |
| LuceneNet_FuzzyQuery  | DefaultJob | Default        | Default     | Default     | medium-edit1-common | 1000          |   268,796.5 ns |     715.35 ns |   669.14 ns | 1,272.92 |    5.00 |  91.3086 |   1.9531 |  383808 B |      856.71 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| LeanCorpus_FuzzyQuery | ShortRun   | 3              | 1           | 3           | medium-edit1-common | 1000          |       208.1 ns |      10.05 ns |     0.55 ns |     1.00 |    0.00 |   0.1070 |        - |     448 B |        1.00 |
| LuceneNet_FuzzyQuery  | ShortRun   | 3              | 1           | 3           | medium-edit1-common | 1000          |   269,767.5 ns |   8,544.99 ns |   468.38 ns | 1,296.60 |    3.55 |  91.3086 |   1.9531 |  383808 B |      856.71 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| **LeanCorpus_FuzzyQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **medium-edit2-common** | **1000**          |     **1,037.1 ns** |       **1.87 ns** |     **1.66 ns** |     **1.00** |    **0.00** |   **0.1297** |        **-** |     **544 B** |        **1.00** |
| LuceneNet_FuzzyQuery  | DefaultJob | Default        | Default     | Default     | medium-edit2-common | 1000          | 1,202,760.9 ns |   4,298.89 ns | 4,021.18 ns | 1,159.74 |    4.16 | 300.7813 |  78.1250 | 1371218 B |    2,520.62 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| LeanCorpus_FuzzyQuery | ShortRun   | 3              | 1           | 3           | medium-edit2-common | 1000          |     1,055.3 ns |      65.80 ns |     3.61 ns |     1.00 |    0.00 |   0.1297 |        - |     544 B |        1.00 |
| LuceneNet_FuzzyQuery  | ShortRun   | 3              | 1           | 3           | medium-edit2-common | 1000          | 1,193,378.1 ns |  62,642.18 ns | 3,433.63 ns | 1,130.88 |    4.38 | 300.7813 |  78.1250 | 1371218 B |    2,520.62 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| **LeanCorpus_FuzzyQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **nohit-edit2**         | **1000**          |       **209.2 ns** |       **0.36 ns** |     **0.32 ns** |     **1.00** |    **0.00** |   **0.1090** |        **-** |     **456 B** |        **1.00** |
| LuceneNet_FuzzyQuery  | DefaultJob | Default        | Default     | Default     | nohit-edit2         | 1000          | 1,631,682.9 ns |   2,845.60 ns | 2,661.78 ns | 7,800.58 |   16.75 | 371.0938 | 134.7656 | 1827052 B |    4,006.69 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| LeanCorpus_FuzzyQuery | ShortRun   | 3              | 1           | 3           | nohit-edit2         | 1000          |       213.5 ns |       3.94 ns |     0.22 ns |     1.00 |    0.00 |   0.1090 |        - |     456 B |        1.00 |
| LuceneNet_FuzzyQuery  | ShortRun   | 3              | 1           | 3           | nohit-edit2         | 1000          | 1,624,412.0 ns | 107,046.12 ns | 5,867.56 ns | 7,608.91 |   24.72 | 373.0469 | 134.7656 | 1827054 B |    4,006.70 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| **LeanCorpus_FuzzyQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **short-edit1-common**  | **1000**          |     **2,470.3 ns** |       **5.28 ns** |     **4.68 ns** |     **1.00** |    **0.00** |   **0.1564** |        **-** |     **664 B** |        **1.00** |
| LuceneNet_FuzzyQuery  | DefaultJob | Default        | Default     | Default     | short-edit1-common  | 1000          |   211,784.3 ns |   2,231.41 ns | 2,087.26 ns |    85.73 |    0.83 |  71.2891 |   0.7324 |  298744 B |      449.92 |
|                       |            |                |             |             |                     |               |                |               |             |          |         |          |          |           |             |
| LeanCorpus_FuzzyQuery | ShortRun   | 3              | 1           | 3           | short-edit1-common  | 1000          |     2,462.9 ns |     134.82 ns |     7.39 ns |     1.00 |    0.00 |   0.1564 |        - |     664 B |        1.00 |
| LuceneNet_FuzzyQuery  | ShortRun   | 3              | 1           | 3           | short-edit1-common  | 1000          |   211,459.7 ns |  44,107.15 ns | 2,417.66 ns |    85.86 |    0.88 |  71.2891 |   0.7324 |  298744 B |      449.92 |

## geo

| Method                         | Job        | IterationCount | LaunchCount | WarmupCount | GeoQueryType | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------------- |----------- |--------------- |------------ |------------ |------------- |-------------- |---------:|----------:|----------:|------:|-------:|----------:|------------:|
| **LeanCorpus_GeoDistanceQuery**    | **DefaultJob** | **Default**        | **Default**     | **Default**     | **BoundingBox**  | **1000**          | **2.484 μs** | **0.0058 μs** | **0.0054 μs** |  **1.00** | **0.2785** |   **1.14 KB** |        **1.00** |
| LeanCorpus_GeoBoundingBoxQuery | DefaultJob | Default        | Default     | Default     | BoundingBox  | 1000          | 3.336 μs | 0.0044 μs | 0.0037 μs |  1.34 | 0.7629 |   3.13 KB |        2.74 |
|                                |            |                |             |             |              |               |          |           |           |       |        |           |             |
| LeanCorpus_GeoDistanceQuery    | ShortRun   | 3              | 1           | 3           | BoundingBox  | 1000          | 2.472 μs | 0.0677 μs | 0.0037 μs |  1.00 | 0.2785 |   1.14 KB |        1.00 |
| LeanCorpus_GeoBoundingBoxQuery | ShortRun   | 3              | 1           | 3           | BoundingBox  | 1000          | 3.331 μs | 0.0794 μs | 0.0044 μs |  1.35 | 0.7629 |   3.13 KB |        2.74 |
|                                |            |                |             |             |              |               |          |           |           |       |        |           |             |
| **LeanCorpus_GeoDistanceQuery**    | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Distance**     | **1000**          | **2.468 μs** | **0.0063 μs** | **0.0059 μs** |  **1.00** | **0.2785** |   **1.14 KB** |        **1.00** |
| LeanCorpus_GeoBoundingBoxQuery | DefaultJob | Default        | Default     | Default     | Distance     | 1000          | 3.341 μs | 0.0057 μs | 0.0053 μs |  1.35 | 0.7629 |   3.13 KB |        2.74 |
|                                |            |                |             |             |              |               |          |           |           |       |        |           |             |
| LeanCorpus_GeoDistanceQuery    | ShortRun   | 3              | 1           | 3           | Distance     | 1000          | 2.485 μs | 0.0492 μs | 0.0027 μs |  1.00 | 0.2785 |   1.14 KB |        1.00 |
| LeanCorpus_GeoBoundingBoxQuery | ShortRun   | 3              | 1           | 3           | Distance     | 1000          | 3.408 μs | 0.1505 μs | 0.0082 μs |  1.37 | 0.7629 |   3.13 KB |        2.74 |

## gutenberg-analysis

| Method                      | Job        | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev   | Median   | Ratio | RatioSD | Gen0       | Gen1      | Gen2      | Allocated | Alloc Ratio |
|---------------------------- |----------- |--------------- |------------ |------------ |---------:|----------:|---------:|---------:|------:|--------:|-----------:|----------:|----------:|----------:|------------:|
| LeanCorpus_Standard_Analyse | DefaultJob | Default        | Default     | Default     | 126.9 ms |   0.69 ms |  0.65 ms | 127.0 ms |  1.00 |    0.00 |  1250.0000 |  750.0000 |         - |   7.27 MB |        1.00 |
| LeanCorpus_English_Analyse  | DefaultJob | Default        | Default     | Default     | 448.0 ms |  12.09 ms | 35.64 ms | 429.3 ms |  3.53 |    0.28 | 13000.0000 | 8000.0000 | 3000.0000 | 199.01 MB |       27.39 |
|                             |            |                |             |             |          |           |          |          |       |         |            |           |           |           |             |
| LeanCorpus_Standard_Analyse | ShortRun   | 3              | 1           | 3           | 126.4 ms |   8.28 ms |  0.45 ms | 126.4 ms |  1.00 |    0.00 |  1250.0000 |  500.0000 |         - |   7.27 MB |        1.00 |
| LeanCorpus_English_Analyse  | ShortRun   | 3              | 1           | 3           | 451.2 ms | 806.03 ms | 44.18 ms | 426.8 ms |  3.57 |    0.30 | 13000.0000 | 9000.0000 | 4000.0000 | 199.01 MB |       27.39 |

## gutenberg-index

| Method                    | Job        | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev   | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated | Alloc Ratio |
|-------------------------- |----------- |--------------- |------------ |------------ |---------:|----------:|---------:|------:|--------:|-----------:|-----------:|----------:|----------:|------------:|
| LeanCorpus_Standard_Index | DefaultJob | Default        | Default     | Default     | 750.6 ms |   6.80 ms |  6.36 ms |  1.00 |    0.00 | 17000.0000 |  9000.0000 | 1000.0000 | 111.89 MB |        1.00 |
| LeanCorpus_English_Index  | DefaultJob | Default        | Default     | Default     | 962.5 ms |   4.72 ms |  4.18 ms |  1.28 |    0.01 | 47000.0000 | 14000.0000 | 1000.0000 | 297.51 MB |        2.66 |
| LuceneNet_Index           | DefaultJob | Default        | Default     | Default     | 630.9 ms |   3.02 ms |  2.36 ms |  0.84 |    0.01 | 42000.0000 |  3000.0000 |         - | 208.13 MB |        1.86 |
|                           |            |                |             |             |          |           |          |       |         |            |            |           |           |             |
| LeanCorpus_Standard_Index | ShortRun   | 3              | 1           | 3           | 746.2 ms |  94.09 ms |  5.16 ms |  1.00 |    0.00 | 16000.0000 |  8000.0000 | 1000.0000 | 111.94 MB |        1.00 |
| LeanCorpus_English_Index  | ShortRun   | 3              | 1           | 3           | 975.6 ms | 226.67 ms | 12.42 ms |  1.31 |    0.02 | 47000.0000 | 14000.0000 | 1000.0000 |  296.4 MB |        2.65 |
| LuceneNet_Index           | ShortRun   | 3              | 1           | 3           | 631.0 ms |  23.10 ms |  1.27 ms |  0.85 |    0.01 | 42000.0000 |  3000.0000 |         - | 208.13 MB |        1.86 |

## gutenberg-search

| Method                     | Job        | IterationCount | LaunchCount | WarmupCount | SearchTerm | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |----------- |--------------- |------------ |------------ |----------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| **LeanCorpus_Standard_Search** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **death**      | **12.85 μs** | **0.057 μs** | **0.053 μs** |  **1.00** |    **0.00** | **0.1068** |      **-** |     **472 B** |        **1.00** |
| LeanCorpus_English_Search  | DefaultJob | Default        | Default     | Default     | death      | 12.75 μs | 0.024 μs | 0.023 μs |  0.99 |    0.00 | 0.1068 |      - |     472 B |        1.00 |
| LuceneNet_Search           | DefaultJob | Default        | Default     | Default     | death      | 22.17 μs | 0.436 μs | 0.408 μs |  1.73 |    0.03 | 2.6550 | 0.0305 |   11231 B |       23.79 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| LeanCorpus_Standard_Search | ShortRun   | 3              | 1           | 3           | death      | 12.95 μs | 0.394 μs | 0.022 μs |  1.00 |    0.00 | 0.1068 |      - |     472 B |        1.00 |
| LeanCorpus_English_Search  | ShortRun   | 3              | 1           | 3           | death      | 12.68 μs | 0.096 μs | 0.005 μs |  0.98 |    0.00 | 0.1068 |      - |     472 B |        1.00 |
| LuceneNet_Search           | ShortRun   | 3              | 1           | 3           | death      | 22.27 μs | 9.831 μs | 0.539 μs |  1.72 |    0.04 | 2.6550 | 0.0305 |   11231 B |       23.79 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| **LeanCorpus_Standard_Search** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **love**       | **16.83 μs** | **0.022 μs** | **0.021 μs** |  **1.00** |    **0.00** | **0.0916** |      **-** |     **464 B** |        **1.00** |
| LeanCorpus_English_Search  | DefaultJob | Default        | Default     | Default     | love       | 22.78 μs | 0.055 μs | 0.052 μs |  1.35 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LuceneNet_Search           | DefaultJob | Default        | Default     | Default     | love       | 29.01 μs | 0.054 μs | 0.051 μs |  1.72 |    0.00 | 2.6245 | 0.0305 |   11175 B |       24.08 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| LeanCorpus_Standard_Search | ShortRun   | 3              | 1           | 3           | love       | 16.97 μs | 0.516 μs | 0.028 μs |  1.00 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LeanCorpus_English_Search  | ShortRun   | 3              | 1           | 3           | love       | 22.26 μs | 0.321 μs | 0.018 μs |  1.31 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LuceneNet_Search           | ShortRun   | 3              | 1           | 3           | love       | 29.09 μs | 1.487 μs | 0.082 μs |  1.71 |    0.00 | 2.6245 | 0.0305 |   11175 B |       24.08 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| **LeanCorpus_Standard_Search** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **man**        | **44.52 μs** | **0.049 μs** | **0.044 μs** |  **1.00** |    **0.00** | **0.0610** |      **-** |     **464 B** |        **1.00** |
| LeanCorpus_English_Search  | DefaultJob | Default        | Default     | Default     | man        | 45.32 μs | 0.109 μs | 0.097 μs |  1.02 |    0.00 | 0.0610 |      - |     464 B |        1.00 |
| LuceneNet_Search           | DefaultJob | Default        | Default     | Default     | man        | 50.45 μs | 0.099 μs | 0.093 μs |  1.13 |    0.00 | 2.6245 | 0.0610 |   11038 B |       23.79 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| LeanCorpus_Standard_Search | ShortRun   | 3              | 1           | 3           | man        | 45.58 μs | 0.673 μs | 0.037 μs |  1.00 |    0.00 | 0.0610 |      - |     464 B |        1.00 |
| LeanCorpus_English_Search  | ShortRun   | 3              | 1           | 3           | man        | 44.53 μs | 1.178 μs | 0.065 μs |  0.98 |    0.00 | 0.0610 |      - |     464 B |        1.00 |
| LuceneNet_Search           | ShortRun   | 3              | 1           | 3           | man        | 50.53 μs | 1.695 μs | 0.093 μs |  1.11 |    0.00 | 2.6245 | 0.0610 |   11038 B |       23.79 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| **LeanCorpus_Standard_Search** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **night**      | **28.75 μs** | **0.040 μs** | **0.037 μs** |  **1.00** |    **0.00** | **0.0916** |      **-** |     **472 B** |        **1.00** |
| LeanCorpus_English_Search  | DefaultJob | Default        | Default     | Default     | night      | 29.82 μs | 0.074 μs | 0.069 μs |  1.04 |    0.00 | 0.0916 |      - |     472 B |        1.00 |
| LuceneNet_Search           | DefaultJob | Default        | Default     | Default     | night      | 35.90 μs | 0.071 μs | 0.067 μs |  1.25 |    0.00 | 2.6245 | 0.0610 |   11223 B |       23.78 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| LeanCorpus_Standard_Search | ShortRun   | 3              | 1           | 3           | night      | 28.37 μs | 0.388 μs | 0.021 μs |  1.00 |    0.00 | 0.0916 |      - |     472 B |        1.00 |
| LeanCorpus_English_Search  | ShortRun   | 3              | 1           | 3           | night      | 30.19 μs | 0.663 μs | 0.036 μs |  1.06 |    0.00 | 0.0916 |      - |     472 B |        1.00 |
| LuceneNet_Search           | ShortRun   | 3              | 1           | 3           | night      | 36.80 μs | 0.980 μs | 0.054 μs |  1.30 |    0.00 | 2.6245 | 0.0610 |   11223 B |       23.78 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| **LeanCorpus_Standard_Search** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **sea**        | **14.04 μs** | **0.035 μs** | **0.032 μs** |  **1.00** |    **0.00** | **0.1068** |      **-** |     **464 B** |        **1.00** |
| LeanCorpus_English_Search  | DefaultJob | Default        | Default     | Default     | sea        | 15.72 μs | 0.025 μs | 0.024 μs |  1.12 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LuceneNet_Search           | DefaultJob | Default        | Default     | Default     | sea        | 26.06 μs | 0.042 μs | 0.035 μs |  1.86 |    0.00 | 2.6550 | 0.0305 |   11271 B |       24.29 |
|                            |            |                |             |             |            |          |          |          |       |         |        |        |           |             |
| LeanCorpus_Standard_Search | ShortRun   | 3              | 1           | 3           | sea        | 14.11 μs | 0.617 μs | 0.034 μs |  1.00 |    0.00 | 0.1068 |      - |     464 B |        1.00 |
| LeanCorpus_English_Search  | ShortRun   | 3              | 1           | 3           | sea        | 15.55 μs | 0.406 μs | 0.022 μs |  1.10 |    0.00 | 0.0916 |      - |     464 B |        1.00 |
| LuceneNet_Search           | ShortRun   | 3              | 1           | 3           | sea        | 26.42 μs | 0.916 μs | 0.050 μs |  1.87 |    0.00 | 2.6550 | 0.0305 |   11271 B |       24.29 |

## highlighter

| Method                         | Job        | IterationCount | LaunchCount | WarmupCount | MaxSnippetLength | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0     | Allocated  | Alloc Ratio |
|------------------------------- |----------- |--------------- |------------ |------------ |----------------- |-------------- |---------:|----------:|----------:|------:|---------:|-----------:|------------:|
| **LeanCorpus_Highlight_TwoTerms**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **100**              | **1000**          | **5.508 ms** | **0.0098 ms** | **0.0086 ms** |  **1.00** | **140.6250** |  **577.67 KB** |        **1.00** |
| LeanCorpus_Highlight_FiveTerms | DefaultJob | Default        | Default     | Default     | 100              | 1000          | 5.789 ms | 0.0117 ms | 0.0110 ms |  1.05 | 148.4375 |  633.06 KB |        1.10 |
|                                |            |                |             |             |                  |               |          |           |           |       |          |            |             |
| LeanCorpus_Highlight_TwoTerms  | ShortRun   | 3              | 1           | 3           | 100              | 1000          | 5.410 ms | 0.1391 ms | 0.0076 ms |  1.00 | 140.6250 |  577.67 KB |        1.00 |
| LeanCorpus_Highlight_FiveTerms | ShortRun   | 3              | 1           | 3           | 100              | 1000          | 5.671 ms | 0.3764 ms | 0.0206 ms |  1.05 | 148.4375 |  633.06 KB |        1.10 |
|                                |            |                |             |             |                  |               |          |           |           |       |          |            |             |
| **LeanCorpus_Highlight_TwoTerms**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **200**              | **1000**          | **5.595 ms** | **0.0127 ms** | **0.0118 ms** |  **1.00** | **187.5000** |  **781.32 KB** |        **1.00** |
| LeanCorpus_Highlight_FiveTerms | DefaultJob | Default        | Default     | Default     | 200              | 1000          | 6.091 ms | 0.0192 ms | 0.0180 ms |  1.09 | 195.3125 |  829.18 KB |        1.06 |
|                                |            |                |             |             |                  |               |          |           |           |       |          |            |             |
| LeanCorpus_Highlight_TwoTerms  | ShortRun   | 3              | 1           | 3           | 200              | 1000          | 5.569 ms | 0.2822 ms | 0.0155 ms |  1.00 | 187.5000 |  781.32 KB |        1.00 |
| LeanCorpus_Highlight_FiveTerms | ShortRun   | 3              | 1           | 3           | 200              | 1000          | 5.760 ms | 0.0946 ms | 0.0052 ms |  1.03 | 195.3125 |  829.18 KB |        1.06 |
|                                |            |                |             |             |                  |               |          |           |           |       |          |            |             |
| **LeanCorpus_Highlight_TwoTerms**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **500**              | **1000**          | **5.723 ms** | **0.0152 ms** | **0.0142 ms** |  **1.00** | **250.0000** | **1028.05 KB** |        **1.00** |
| LeanCorpus_Highlight_FiveTerms | DefaultJob | Default        | Default     | Default     | 500              | 1000          | 6.029 ms | 0.0115 ms | 0.0108 ms |  1.05 | 257.8125 | 1062.96 KB |        1.03 |
|                                |            |                |             |             |                  |               |          |           |           |       |          |            |             |
| LeanCorpus_Highlight_TwoTerms  | ShortRun   | 3              | 1           | 3           | 500              | 1000          | 5.775 ms | 0.2954 ms | 0.0162 ms |  1.00 | 250.0000 | 1028.05 KB |        1.00 |
| LeanCorpus_Highlight_FiveTerms | ShortRun   | 3              | 1           | 3           | 500              | 1000          | 6.096 ms | 0.2827 ms | 0.0155 ms |  1.06 | 257.8125 | 1062.96 KB |        1.03 |

## hunspell

| Method           | Job        | IterationCount | LaunchCount | WarmupCount | Mean     | Error    | StdDev  | Gen0   | Allocated |
|----------------- |----------- |--------------- |------------ |------------ |---------:|---------:|--------:|-------:|----------:|
| Parse_Dictionary | DefaultJob | Default        | Default     | Default     | 294.7 ns |  0.58 ns | 0.54 ns | 0.0420 |     176 B |
| Stem_Words       | DefaultJob | Default        | Default     | Default     | 100.7 ns |  0.09 ns | 0.08 ns |      - |         - |
| Parse_Dictionary | ShortRun   | 3              | 1           | 3           | 296.7 ns | 10.09 ns | 0.55 ns | 0.0420 |     176 B |
| Stem_Words       | ShortRun   | 3              | 1           | 3           | 100.8 ns |  3.21 ns | 0.18 ns |      - |         - |

## Indexing

| Method                    | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error     | StdDev   | Ratio | RatioSD | Gen0      | Gen1     | Allocated | Alloc Ratio |
|-------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|----------:|---------:|------:|--------:|----------:|---------:|----------:|------------:|
| LeanCorpus_IndexDocuments | DefaultJob | Default        | Default     | Default     | 1000          | 36.98 ms |  0.736 ms | 1.705 ms |  1.00 |    0.00 |  928.5714 | 214.2857 |   7.93 MB |        1.00 |
| LuceneNet_IndexDocuments  | DefaultJob | Default        | Default     | Default     | 1000          | 28.91 ms |  0.116 ms | 0.108 ms |  0.78 |    0.04 | 2968.7500 | 625.0000 |  15.51 MB |        1.96 |
|                           |            |                |             |             |               |          |           |          |       |         |           |          |           |             |
| LeanCorpus_IndexDocuments | ShortRun   | 3              | 1           | 3           | 1000          | 37.16 ms | 31.668 ms | 1.736 ms |  1.00 |    0.00 |  928.5714 | 214.2857 |   7.93 MB |        1.00 |
| LuceneNet_IndexDocuments  | ShortRun   | 3              | 1           | 3           | 1000          | 28.59 ms |  1.705 ms | 0.093 ms |  0.77 |    0.03 | 2968.7500 | 625.0000 |  15.51 MB |        1.96 |

## Index-sort (index)

| Method                    | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error    | StdDev   | Ratio | Gen0      | Gen1     | Allocated | Alloc Ratio |
|-------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|---------:|---------:|------:|----------:|---------:|----------:|------------:|
| LeanCorpus_Index_Unsorted | DefaultJob | Default        | Default     | Default     | 1000          | 39.64 ms | 0.288 ms | 0.270 ms |  1.00 | 1076.9231 | 923.0769 |   8.75 MB |        1.00 |
| LeanCorpus_Index_Sorted   | DefaultJob | Default        | Default     | Default     | 1000          | 43.67 ms | 0.257 ms | 0.241 ms |  1.10 | 1166.6667 | 916.6667 |   9.06 MB |        1.04 |
|                           |            |                |             |             |               |          |          |          |       |           |          |           |             |
| LeanCorpus_Index_Unsorted | ShortRun   | 3              | 1           | 3           | 1000          | 39.46 ms | 1.957 ms | 0.107 ms |  1.00 | 1076.9231 | 923.0769 |   8.75 MB |        1.00 |
| LeanCorpus_Index_Sorted   | ShortRun   | 3              | 1           | 3           | 1000          | 43.68 ms | 5.117 ms | 0.280 ms |  1.11 | 1166.6667 | 916.6667 |   9.06 MB |        1.04 |

## Index-sort (search)

| Method                                   | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|---------:|--------:|------:|-------:|----------:|------------:|
| LeanCorpus_SortedSearch_EarlyTermination | DefaultJob | Default        | Default     | Default     | 1000          | 321.5 ns |  0.66 ns | 0.61 ns |  1.00 | 0.0744 |     312 B |        1.00 |
| LeanCorpus_SortedSearch_PostSort         | DefaultJob | Default        | Default     | Default     | 1000          | 321.7 ns |  0.48 ns | 0.40 ns |  1.00 | 0.0744 |     312 B |        1.00 |
|                                          |            |                |             |             |               |          |          |         |       |        |           |             |
| LeanCorpus_SortedSearch_EarlyTermination | ShortRun   | 3              | 1           | 3           | 1000          | 324.5 ns | 12.88 ns | 0.71 ns |  1.00 | 0.0744 |     312 B |        1.00 |
| LeanCorpus_SortedSearch_PostSort         | ShortRun   | 3              | 1           | 3           | 1000          | 325.7 ns | 11.41 ns | 0.63 ns |  1.00 | 0.0744 |     312 B |        1.00 |

## kstemmer

| Method        | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error     | StdDev    | Gen0      | Gen1    | Allocated |
|-------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|----------:|----------:|----------:|--------:|----------:|
| KStem_Analyse | DefaultJob | Default        | Default     | Default     | 1000          | 9.842 ms | 0.0363 ms | 0.0303 ms | 1718.7500 | 15.6250 |   6.87 MB |
| KStem_Analyse | ShortRun   | 3              | 1           | 3           | 1000          | 9.901 ms | 1.0477 ms | 0.0574 ms | 1718.7500 | 15.6250 |   6.87 MB |

## lightenglish

| Method            | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0    | Gen1    | Allocated | Alloc Ratio |
|------------------ |----------- |--------------- |------------ |------------ |-------------- |---------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| LightEnglish_Stem | DefaultJob | Default        | Default     | Default     | 1000          | 2.654 ms | 0.0075 ms | 0.0070 ms |  1.00 | 93.7500 |       - | 389.65 KB |        1.00 |
| Porter_Stem       | DefaultJob | Default        | Default     | Default     | 1000          | 3.538 ms | 0.0067 ms | 0.0063 ms |  1.33 | 89.8438 | 11.7188 | 368.09 KB |        0.94 |
|                   |            |                |             |             |               |          |           |           |       |         |         |           |             |
| LightEnglish_Stem | ShortRun   | 3              | 1           | 3           | 1000          | 2.577 ms | 0.1412 ms | 0.0077 ms |  1.00 | 93.7500 |       - | 389.65 KB |        1.00 |
| Porter_Stem       | ShortRun   | 3              | 1           | 3           | 1000          | 3.497 ms | 0.0880 ms | 0.0048 ms |  1.36 | 89.8438 | 11.7188 | 368.09 KB |        0.94 |

## mlt

| Method                                      | Job        | IterationCount | LaunchCount | WarmupCount | MaxQueryTerms | DocumentCount | Mean       | Error      | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |-------------- |-----------:|-----------:|----------:|------:|-------:|----------:|------------:|
| **LeanCorpus_MoreLikeThisQuery_DefaultParams**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **10**            | **1000**          |  **20.567 μs** |  **0.0424 μs** | **0.0397 μs** |  **1.00** | **3.6926** |  **15.09 KB** |        **1.00** |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | DefaultJob | Default        | Default     | Default     | 10            | 1000          |   6.992 μs |  0.0139 μs | 0.0130 μs |  0.34 | 1.6861 |    6.9 KB |        0.46 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | DefaultJob | Default        | Default     | Default     | 10            | 1000          |  20.489 μs |  0.0448 μs | 0.0419 μs |  1.00 | 3.6926 |  15.09 KB |        1.00 |
|                                             |            |                |             |             |               |               |            |            |           |       |        |           |             |
| LeanCorpus_MoreLikeThisQuery_DefaultParams  | ShortRun   | 3              | 1           | 3           | 10            | 1000          |  20.398 μs |  1.6817 μs | 0.0922 μs |  1.00 | 3.6926 |  15.09 KB |        1.00 |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | ShortRun   | 3              | 1           | 3           | 10            | 1000          |   7.038 μs |  0.2859 μs | 0.0157 μs |  0.35 | 1.6861 |    6.9 KB |        0.46 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | ShortRun   | 3              | 1           | 3           | 10            | 1000          |  20.271 μs |  0.6788 μs | 0.0372 μs |  0.99 | 3.6926 |  15.09 KB |        1.00 |
|                                             |            |                |             |             |               |               |            |            |           |       |        |           |             |
| **LeanCorpus_MoreLikeThisQuery_DefaultParams**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **25**            | **1000**          |  **39.909 μs** |  **0.0972 μs** | **0.0909 μs** |  **1.00** | **5.1880** |  **21.35 KB** |        **1.00** |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | DefaultJob | Default        | Default     | Default     | 25            | 1000          |   6.975 μs |  0.0205 μs | 0.0191 μs |  0.17 | 1.6861 |    6.9 KB |        0.32 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | DefaultJob | Default        | Default     | Default     | 25            | 1000          |  39.698 μs |  0.0700 μs | 0.0655 μs |  0.99 | 5.1880 |  21.35 KB |        1.00 |
|                                             |            |                |             |             |               |               |            |            |           |       |        |           |             |
| LeanCorpus_MoreLikeThisQuery_DefaultParams  | ShortRun   | 3              | 1           | 3           | 25            | 1000          |  40.286 μs |  2.7853 μs | 0.1527 μs |  1.00 | 5.1880 |  21.35 KB |        1.00 |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | ShortRun   | 3              | 1           | 3           | 25            | 1000          |   7.168 μs |  0.4200 μs | 0.0230 μs |  0.18 | 1.6861 |    6.9 KB |        0.32 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | ShortRun   | 3              | 1           | 3           | 25            | 1000          |  39.650 μs |  1.6961 μs | 0.0930 μs |  0.98 | 5.1880 |  21.35 KB |        1.00 |
|                                             |            |                |             |             |               |               |            |            |           |       |        |           |             |
| **LeanCorpus_MoreLikeThisQuery_DefaultParams**  | **DefaultJob** | **Default**        | **Default**     | **Default**     | **50**            | **1000**          | **136.389 μs** |  **0.3698 μs** | **0.3459 μs** |  **1.00** | **6.5918** |  **27.13 KB** |        **1.00** |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | DefaultJob | Default        | Default     | Default     | 50            | 1000          |   7.060 μs |  0.0060 μs | 0.0047 μs |  0.05 | 1.6861 |    6.9 KB |        0.25 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | DefaultJob | Default        | Default     | Default     | 50            | 1000          | 136.874 μs |  0.4127 μs | 0.3861 μs |  1.00 | 6.5918 |  27.13 KB |        1.00 |
|                                             |            |                |             |             |               |               |            |            |           |       |        |           |             |
| LeanCorpus_MoreLikeThisQuery_DefaultParams  | ShortRun   | 3              | 1           | 3           | 50            | 1000          | 136.594 μs | 11.1116 μs | 0.6091 μs |  1.00 | 6.5918 |  27.13 KB |        1.00 |
| LeanCorpus_MoreLikeThisQuery_HighMinDocFreq | ShortRun   | 3              | 1           | 3           | 50            | 1000          |   7.073 μs |  0.3417 μs | 0.0187 μs |  0.05 | 1.6861 |    6.9 KB |        0.25 |
| LeanCorpus_MoreLikeThisQuery_NoBoost        | ShortRun   | 3              | 1           | 3           | 50            | 1000          | 137.098 μs | 14.0227 μs | 0.7686 μs |  1.00 | 6.5918 |  27.13 KB |        1.00 |

## multiphrase

| Method                      | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |----------- |--------------- |------------ |------------ |-------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LeanCorpus_MultiPhraseQuery | DefaultJob | Default        | Default     | Default     | 1000          |  1.076 μs | 0.0027 μs | 0.0025 μs |  1.00 |    0.00 | 0.6351 |    2.6 KB |        1.00 |
| LuceneNet_MultiPhraseQuery  | DefaultJob | Default        | Default     | Default     | 1000          | 11.149 μs | 0.0260 μs | 0.0243 μs | 10.36 |    0.03 | 7.6294 |   31.2 KB |       11.99 |
|                             |            |                |             |             |               |           |           |           |       |         |        |           |             |
| LeanCorpus_MultiPhraseQuery | ShortRun   | 3              | 1           | 3           | 1000          |  1.056 μs | 0.0816 μs | 0.0045 μs |  1.00 |    0.00 | 0.6351 |    2.6 KB |        1.00 |
| LuceneNet_MultiPhraseQuery  | ShortRun   | 3              | 1           | 3           | 1000          | 11.399 μs | 0.7957 μs | 0.0436 μs | 10.79 |    0.05 | 7.6294 |   31.2 KB |       11.99 |

## ngram

| Method                                        | Job        | IterationCount | LaunchCount | WarmupCount | GramRange | DocumentCount | Mean        | Error     | StdDev   | Ratio | RatioSD | Gen0      | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------------- |----------- |--------------- |------------ |------------ |---------- |-------------- |------------:|----------:|---------:|------:|--------:|----------:|-------:|----------:|------------:|
| **LeanCorpus_EdgeNGramTokeniser_SpanSink**        | **DefaultJob** | **Default**        | **Default**     | **Default**     | **2-3**       | **1000**          |    **844.3 μs** |   **1.74 μs** |  **1.63 μs** |  **1.00** |    **0.00** |         **-** |      **-** |         **-** |          **NA** |
| LeanCorpus_NGramTokeniser_SpanSink            | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |    812.2 μs |   0.57 μs |  0.50 μs |  0.96 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_SpanSink  | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |  1,231.8 μs |   3.66 μs |  3.06 μs |  1.46 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_EdgeNGramTokeniser_Streaming       | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |  1,161.2 μs |   1.72 μs |  1.53 μs |  1.38 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_Streaming           | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |  2,727.9 μs |   3.42 μs |  3.20 μs |  3.23 |    0.01 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_Streaming | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |  2,745.7 μs |   3.21 μs |  2.84 μs |  3.25 |    0.01 |         - |      - |         - |          NA |
| LuceneNet_EdgeNGramTokenizer                  | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          |  4,094.9 μs |  21.99 μs | 20.57 μs |  4.85 |    0.03 | 2117.1875 |      - | 8856000 B |          NA |
| LuceneNet_NGramTokenizer                      | DefaultJob | Default        | Default     | Default     | 2-3       | 1000          | 17,281.2 μs |  71.67 μs | 67.04 μs | 20.47 |    0.09 | 2093.7500 |      - | 8856000 B |          NA |
|                                               |            |                |             |             |           |               |             |           |          |       |         |           |        |           |             |
| LeanCorpus_EdgeNGramTokeniser_SpanSink        | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |    833.8 μs |   9.80 μs |  0.54 μs |  1.00 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_SpanSink            | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |    810.2 μs |   5.60 μs |  0.31 μs |  0.97 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_SpanSink  | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |  1,218.5 μs |  51.34 μs |  2.81 μs |  1.46 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_EdgeNGramTokeniser_Streaming       | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |  1,162.1 μs |  51.89 μs |  2.84 μs |  1.39 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_Streaming           | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |  2,734.9 μs |  18.14 μs |  0.99 μs |  3.28 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_Streaming | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |  2,738.7 μs |  36.58 μs |  2.00 μs |  3.28 |    0.00 |         - |      - |         - |          NA |
| LuceneNet_EdgeNGramTokenizer                  | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          |  4,092.3 μs |  95.39 μs |  5.23 μs |  4.91 |    0.01 | 2117.1875 | 7.8125 | 8856000 B |          NA |
| LuceneNet_NGramTokenizer                      | ShortRun   | 3              | 1           | 3           | 2-3       | 1000          | 17,223.7 μs | 741.01 μs | 40.62 μs | 20.66 |    0.04 | 2093.7500 |      - | 8856000 B |          NA |
|                                               |            |                |             |             |           |               |             |           |          |       |         |           |        |           |             |
| **LeanCorpus_EdgeNGramTokeniser_SpanSink**        | **DefaultJob** | **Default**        | **Default**     | **Default**     | **3-5**       | **1000**          |    **860.1 μs** |   **1.16 μs** |  **1.03 μs** |  **1.00** |    **0.00** |         **-** |      **-** |         **-** |          **NA** |
| LeanCorpus_NGramTokeniser_SpanSink            | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  1,221.5 μs |   1.33 μs |  1.11 μs |  1.42 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_SpanSink  | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  1,245.1 μs |   2.24 μs |  2.09 μs |  1.45 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_EdgeNGramTokeniser_Streaming       | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  1,242.0 μs |   2.10 μs |  1.86 μs |  1.44 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_Streaming           | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  3,866.6 μs |   4.65 μs |  4.35 μs |  4.50 |    0.01 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_Streaming | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  2,609.5 μs |   3.70 μs |  3.46 μs |  3.03 |    0.01 |         - |      - |         - |          NA |
| LuceneNet_EdgeNGramTokenizer                  | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          |  4,189.2 μs |  17.91 μs | 16.76 μs |  4.87 |    0.02 | 2117.1875 |      - | 8880000 B |          NA |
| LuceneNet_NGramTokenizer                      | DefaultJob | Default        | Default     | Default     | 3-5       | 1000          | 26,825.9 μs |  64.22 μs | 56.93 μs | 31.19 |    0.07 | 2093.7500 |      - | 8880000 B |          NA |
|                                               |            |                |             |             |           |               |             |           |          |       |         |           |        |           |             |
| LeanCorpus_EdgeNGramTokeniser_SpanSink        | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |    897.6 μs |  43.85 μs |  2.40 μs |  1.00 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_SpanSink            | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  1,222.0 μs |  25.26 μs |  1.38 μs |  1.36 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_SpanSink  | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  1,234.9 μs |  47.94 μs |  2.63 μs |  1.38 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_EdgeNGramTokeniser_Streaming       | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  1,228.9 μs |  60.52 μs |  3.32 μs |  1.37 |    0.00 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_Streaming           | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  3,856.0 μs |  52.79 μs |  2.89 μs |  4.30 |    0.01 |         - |      - |         - |          NA |
| LeanCorpus_NGramTokeniser_WordSplit_Streaming | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  2,602.9 μs |  87.47 μs |  4.79 μs |  2.90 |    0.01 |         - |      - |         - |          NA |
| LuceneNet_EdgeNGramTokenizer                  | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          |  4,286.9 μs | 109.82 μs |  6.02 μs |  4.78 |    0.01 | 2117.1875 |      - | 8880000 B |          NA |
| LuceneNet_NGramTokenizer                      | ShortRun   | 3              | 1           | 3           | 3-5       | 1000          | 27,389.3 μs | 817.39 μs | 44.80 μs | 30.51 |    0.08 | 2093.7500 |      - | 8880000 B |          NA |

## parallel

| Method                                 | Job        | IterationCount | LaunchCount | WarmupCount | SegmentCount | DocumentCount | Mean        | Error       | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |--------------- |------------ |------------ |------------- |-------------- |------------:|------------:|---------:|------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_SequentialSearch**            | **DefaultJob** | **Default**        | **Default**     | **Default**     | **4**            | **1000**          |    **830.3 ns** |     **1.92 ns** |  **1.79 ns** |  **1.00** |    **0.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_ParallelSearch              | DefaultJob | Default        | Default     | Default     | 4            | 1000          |    831.3 ns |     1.28 ns |  1.14 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch_BooleanQuery | DefaultJob | Default        | Default     | Default     | 4            | 1000          |  7,644.1 ns |    26.36 ns | 23.37 ns |  9.21 |    0.03 | 2.0294 |    8392 B |       32.78 |
|                                        |            |                |             |             |              |               |             |             |          |       |         |        |           |             |
| LeanCorpus_SequentialSearch            | ShortRun   | 3              | 1           | 3           | 4            | 1000          |  1,045.7 ns |    40.93 ns |  2.24 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch              | ShortRun   | 3              | 1           | 3           | 4            | 1000          |    847.8 ns |    66.84 ns |  3.66 ns |  0.81 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch_BooleanQuery | ShortRun   | 3              | 1           | 3           | 4            | 1000          |  7,952.1 ns |   963.74 ns | 52.83 ns |  7.60 |    0.05 | 2.0294 |    8392 B |       32.78 |
|                                        |            |                |             |             |              |               |             |             |          |       |         |        |           |             |
| **LeanCorpus_SequentialSearch**            | **DefaultJob** | **Default**        | **Default**     | **Default**     | **8**            | **1000**          |  **1,507.9 ns** |     **3.90 ns** |  **3.65 ns** |  **1.00** |    **0.00** | **0.0610** |     **256 B** |        **1.00** |
| LeanCorpus_ParallelSearch              | DefaultJob | Default        | Default     | Default     | 8            | 1000          |  1,504.9 ns |     4.07 ns |  3.81 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch_BooleanQuery | DefaultJob | Default        | Default     | Default     | 8            | 1000          | 10,876.3 ns |    73.85 ns | 69.08 ns |  7.21 |    0.05 | 3.1891 |   13192 B |       51.53 |
|                                        |            |                |             |             |              |               |             |             |          |       |         |        |           |             |
| LeanCorpus_SequentialSearch            | ShortRun   | 3              | 1           | 3           | 8            | 1000          |  1,527.5 ns |    46.79 ns |  2.56 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch              | ShortRun   | 3              | 1           | 3           | 8            | 1000          |  1,517.1 ns |    95.63 ns |  5.24 ns |  0.99 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_ParallelSearch_BooleanQuery | ShortRun   | 3              | 1           | 3           | 8            | 1000          | 11,215.6 ns | 1,460.32 ns | 80.04 ns |  7.34 |    0.05 | 3.1891 |   13192 B |       51.53 |

## Phrase queries

| Method                 | Job        | IterationCount | LaunchCount | WarmupCount | PhraseType     | DocumentCount | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |----------- |--------------- |------------ |------------ |--------------- |-------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_PhraseQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **ExactThreeWord** | **1000**          | **2.160 μs** | **0.0040 μs** | **0.0035 μs** |  **1.00** |    **0.00** | **0.7744** |   **3.17 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | DefaultJob | Default        | Default     | Default     | ExactThreeWord | 1000          | 9.162 μs | 0.0586 μs | 0.0548 μs |  4.24 |    0.03 | 6.3324 |   25.9 KB |        8.17 |
|                        |            |                |             |             |                |               |          |           |           |       |         |        |           |             |
| LeanCorpus_PhraseQuery | ShortRun   | 3              | 1           | 3           | ExactThreeWord | 1000          | 2.075 μs | 0.1912 μs | 0.0105 μs |  1.00 |    0.00 | 0.7744 |   3.17 KB |        1.00 |
| LuceneNet_PhraseQuery  | ShortRun   | 3              | 1           | 3           | ExactThreeWord | 1000          | 9.167 μs | 1.4600 μs | 0.0800 μs |  4.42 |    0.04 | 6.3324 |   25.9 KB |        8.17 |
|                        |            |                |             |             |                |               |          |           |           |       |         |        |           |             |
| **LeanCorpus_PhraseQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **ExactTwoWord**   | **1000**          | **1.912 μs** | **0.0025 μs** | **0.0021 μs** |  **1.00** |    **0.00** | **0.7019** |   **2.87 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | DefaultJob | Default        | Default     | Default     | ExactTwoWord   | 1000          | 6.592 μs | 0.0163 μs | 0.0152 μs |  3.45 |    0.01 | 4.6463 |  18.98 KB |        6.62 |
|                        |            |                |             |             |                |               |          |           |           |       |         |        |           |             |
| LeanCorpus_PhraseQuery | ShortRun   | 3              | 1           | 3           | ExactTwoWord   | 1000          | 1.878 μs | 0.0720 μs | 0.0039 μs |  1.00 |    0.00 | 0.7019 |   2.87 KB |        1.00 |
| LuceneNet_PhraseQuery  | ShortRun   | 3              | 1           | 3           | ExactTwoWord   | 1000          | 6.866 μs | 0.2737 μs | 0.0150 μs |  3.66 |    0.01 | 4.6463 |  18.98 KB |        6.62 |
|                        |            |                |             |             |                |               |          |           |           |       |         |        |           |             |
| **LeanCorpus_PhraseQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **SlopTwoWord**    | **1000**          | **8.463 μs** | **0.0243 μs** | **0.0227 μs** |  **1.00** |    **0.00** | **0.7019** |    **2.9 KB** |        **1.00** |
| LuceneNet_PhraseQuery  | DefaultJob | Default        | Default     | Default     | SlopTwoWord    | 1000          | 6.540 μs | 0.0106 μs | 0.0089 μs |  0.77 |    0.00 | 4.8141 |  19.68 KB |        6.79 |
|                        |            |                |             |             |                |               |          |           |           |       |         |        |           |             |
| LeanCorpus_PhraseQuery | ShortRun   | 3              | 1           | 3           | SlopTwoWord    | 1000          | 8.492 μs | 0.3328 μs | 0.0182 μs |  1.00 |    0.00 | 0.7019 |    2.9 KB |        1.00 |
| LuceneNet_PhraseQuery  | ShortRun   | 3              | 1           | 3           | SlopTwoWord    | 1000          | 6.621 μs | 0.0972 μs | 0.0053 μs |  0.78 |    0.00 | 4.8141 |  19.68 KB |        6.79 |

## Prefix queries

| Method                 | Job        | IterationCount | LaunchCount | WarmupCount | QueryPrefix | DocumentCount | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------- |----------- |--------------- |------------ |------------ |------------ |-------------- |------------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| **LeanCorpus_PrefixQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **gov**         | **1000**          |    **474.3 ns** |   **1.14 ns** |   **1.01 ns** |  **1.00** |    **0.00** |  **0.1163** |     **488 B** |        **1.00** |
| LuceneNet_PrefixQuery  | DefaultJob | Default        | Default     | Default     | gov         | 1000          | 28,290.6 ns | 117.93 ns | 110.31 ns | 59.65 |    0.26 | 29.8462 |  125096 B |      256.34 |
|                        |            |                |             |             |             |               |             |           |           |       |         |         |           |             |
| LeanCorpus_PrefixQuery | ShortRun   | 3              | 1           | 3           | gov         | 1000          |    532.1 ns |  63.53 ns |   3.48 ns |  1.00 |    0.00 |  0.1163 |     488 B |        1.00 |
| LuceneNet_PrefixQuery  | ShortRun   | 3              | 1           | 3           | gov         | 1000          | 28,199.8 ns | 596.04 ns |  32.67 ns | 53.00 |    0.30 | 29.8462 |  125096 B |      256.34 |
|                        |            |                |             |             |             |               |             |           |           |       |         |         |           |             |
| **LeanCorpus_PrefixQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **mark**        | **1000**          |  **1,437.2 ns** |   **3.31 ns** |   **3.09 ns** |  **1.00** |    **0.00** |  **0.1564** |     **656 B** |        **1.00** |
| LuceneNet_PrefixQuery  | DefaultJob | Default        | Default     | Default     | mark        | 1000          |  9,956.5 ns |  27.54 ns |  25.76 ns |  6.93 |    0.02 | 12.4969 |   52544 B |       80.10 |
|                        |            |                |             |             |             |               |             |           |           |       |         |         |           |             |
| LeanCorpus_PrefixQuery | ShortRun   | 3              | 1           | 3           | mark        | 1000          |  1,435.3 ns |  81.16 ns |   4.45 ns |  1.00 |    0.00 |  0.1564 |     656 B |        1.00 |
| LuceneNet_PrefixQuery  | ShortRun   | 3              | 1           | 3           | mark        | 1000          | 10,204.1 ns | 397.04 ns |  21.76 ns |  7.11 |    0.02 | 12.4969 |   52544 B |       80.10 |
|                        |            |                |             |             |             |               |             |           |           |       |         |         |           |             |
| **LeanCorpus_PrefixQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **pres**        | **1000**          |  **4,059.0 ns** |  **11.45 ns** |  **10.71 ns** |  **1.00** |    **0.00** |  **0.2365** |    **1008 B** |        **1.00** |
| LuceneNet_PrefixQuery  | DefaultJob | Default        | Default     | Default     | pres        | 1000          | 11,936.6 ns |  32.17 ns |  30.09 ns |  2.94 |    0.01 | 12.6495 |   53040 B |       52.62 |
|                        |            |                |             |             |             |               |             |           |           |       |         |         |           |             |
| LeanCorpus_PrefixQuery | ShortRun   | 3              | 1           | 3           | pres        | 1000          |  4,127.5 ns | 220.92 ns |  12.11 ns |  1.00 |    0.00 |  0.2365 |    1008 B |        1.00 |
| LuceneNet_PrefixQuery  | ShortRun   | 3              | 1           | 3           | pres        | 1000          | 12,286.5 ns | 594.78 ns |  32.60 ns |  2.98 |    0.01 | 12.6495 |   53040 B |       52.62 |

## Term queries

| Method               | Job        | IterationCount | LaunchCount | WarmupCount | QueryTerm  | DocumentCount | Mean        | Error     | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |----------- |--------------- |------------ |------------ |----------- |-------------- |------------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_TermQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **government** | **1000**          |    **309.5 ns** |   **0.87 ns** |  **0.82 ns** |  **1.00** |    **0.00** | **0.0610** |     **256 B** |        **1.00** |
| LuceneNet_TermQuery  | DefaultJob | Default        | Default     | Default     | government | 1000          |  2,762.2 ns |   6.34 ns |  5.93 ns |  8.93 |    0.03 | 2.0409 |    8544 B |       33.38 |
|                      |            |                |             |             |            |               |             |           |          |       |         |        |           |             |
| LeanCorpus_TermQuery | ShortRun   | 3              | 1           | 3           | government | 1000          |    312.2 ns | 166.06 ns |  9.10 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LuceneNet_TermQuery  | ShortRun   | 3              | 1           | 3           | government | 1000          |  2,893.5 ns |  44.54 ns |  2.44 ns |  9.27 |    0.23 | 2.0409 |    8544 B |       33.38 |
|                      |            |                |             |             |            |               |             |           |          |       |         |        |           |             |
| **LeanCorpus_TermQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **people**     | **1000**          |  **1,121.4 ns** |   **2.86 ns** |  **2.67 ns** |  **1.00** |    **0.00** | **0.1011** |     **424 B** |        **1.00** |
| LuceneNet_TermQuery  | DefaultJob | Default        | Default     | Default     | people     | 1000          |  7,738.9 ns |  14.38 ns | 13.45 ns |  6.90 |    0.02 | 3.1433 |   13208 B |       31.15 |
|                      |            |                |             |             |            |               |             |           |          |       |         |        |           |             |
| LeanCorpus_TermQuery | ShortRun   | 3              | 1           | 3           | people     | 1000          |  1,155.8 ns |  50.97 ns |  2.79 ns |  1.00 |    0.00 | 0.1011 |     424 B |        1.00 |
| LuceneNet_TermQuery  | ShortRun   | 3              | 1           | 3           | people     | 1000          |  7,728.6 ns | 684.27 ns | 37.51 ns |  6.69 |    0.03 | 3.1433 |   13208 B |       31.15 |
|                      |            |                |             |             |            |               |             |           |          |       |         |        |           |             |
| **LeanCorpus_TermQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **said**       | **1000**          | **12,588.4 ns** |  **44.71 ns** | **41.83 ns** |  **1.00** |    **0.00** | **0.1068** |     **464 B** |        **1.00** |
| LuceneNet_TermQuery  | DefaultJob | Default        | Default     | Default     | said       | 1000          | 19,377.4 ns |  51.15 ns | 45.34 ns |  1.54 |    0.01 | 3.1128 |   13072 B |       28.17 |
|                      |            |                |             |             |            |               |             |           |          |       |         |        |           |             |
| LeanCorpus_TermQuery | ShortRun   | 3              | 1           | 3           | said       | 1000          | 13,248.7 ns | 895.28 ns | 49.07 ns |  1.00 |    0.00 | 0.1068 |     464 B |        1.00 |
| LuceneNet_TermQuery  | ShortRun   | 3              | 1           | 3           | said       | 1000          | 19,648.5 ns | 796.11 ns | 43.64 ns |  1.48 |    0.01 | 3.1128 |   13072 B |       28.17 |

## query-cache

| Method                            | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean       | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |----------- |--------------- |------------ |------------ |-------------- |-----------:|---------:|--------:|------:|-------:|----------:|------------:|
| LeanCorpus_NoCache                | DefaultJob | Default        | Default     | Default     | 1000          |   305.3 ns |  0.67 ns | 0.63 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_WithCache              | DefaultJob | Default        | Default     | Default     | 1000          |   281.9 ns |  0.79 ns | 0.74 ns |  0.92 | 0.1183 |     496 B |        1.94 |
| LeanCorpus_WithCache_BooleanQuery | DefaultJob | Default        | Default     | Default     | 1000          |   741.3 ns |  1.49 ns | 1.39 ns |  2.43 | 0.2518 |    1056 B |        4.12 |
| LeanCorpus_NoCache_BooleanQuery   | DefaultJob | Default        | Default     | Default     | 1000          | 1,519.6 ns |  3.55 ns | 3.32 ns |  4.98 | 0.4616 |    1936 B |        7.56 |
|                                   |            |                |             |             |               |            |          |         |       |        |           |             |
| LeanCorpus_NoCache                | ShortRun   | 3              | 1           | 3           | 1000          |   305.8 ns | 10.35 ns | 0.57 ns |  1.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_WithCache              | ShortRun   | 3              | 1           | 3           | 1000          |   278.2 ns | 12.32 ns | 0.68 ns |  0.91 | 0.1183 |     496 B |        1.94 |
| LeanCorpus_WithCache_BooleanQuery | ShortRun   | 3              | 1           | 3           | 1000          |   748.1 ns | 15.73 ns | 0.86 ns |  2.45 | 0.2518 |    1056 B |        4.12 |
| LeanCorpus_NoCache_BooleanQuery   | ShortRun   | 3              | 1           | 3           | 1000          | 1,511.7 ns | 65.63 ns | 3.60 ns |  4.94 | 0.4616 |    1936 B |        7.56 |

## range

| Method                      | Job        | IterationCount | LaunchCount | WarmupCount | RangeWidth | DocumentCount | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------- |----------- |--------------- |------------ |------------ |----------- |-------------- |----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| **LeanCorpus_RangeQuery**       | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0.01**       | **1000**          |  **2.484 μs** | **0.0054 μs** | **0.0051 μs** |  **1.00** |    **0.00** |  **0.1984** |     **840 B** |        **1.00** |
| LuceneNet_NumericRangeQuery | DefaultJob | Default        | Default     | Default     | 0.01       | 1000          | 14.476 μs | 0.0415 μs | 0.0346 μs |  5.83 |    0.02 | 13.1531 |   55064 B |       65.55 |
|                             |            |                |             |             |            |               |           |           |           |       |         |         |           |             |
| LeanCorpus_RangeQuery       | ShortRun   | 3              | 1           | 3           | 0.01       | 1000          |  2.489 μs | 0.0803 μs | 0.0044 μs |  1.00 |    0.00 |  0.1984 |     840 B |        1.00 |
| LuceneNet_NumericRangeQuery | ShortRun   | 3              | 1           | 3           | 0.01       | 1000          | 14.264 μs | 0.1221 μs | 0.0067 μs |  5.73 |    0.01 | 13.1531 |   55064 B |       65.55 |
|                             |            |                |             |             |            |               |           |           |           |       |         |         |           |             |
| **LeanCorpus_RangeQuery**       | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0.1**        | **1000**          |  **4.601 μs** | **0.0085 μs** | **0.0079 μs** |  **1.00** |    **0.00** |  **0.2213** |     **952 B** |        **1.00** |
| LuceneNet_NumericRangeQuery | DefaultJob | Default        | Default     | Default     | 0.1        | 1000          | 16.628 μs | 0.0461 μs | 0.0432 μs |  3.61 |    0.01 | 12.8174 |   53880 B |       56.60 |
|                             |            |                |             |             |            |               |           |           |           |       |         |         |           |             |
| LeanCorpus_RangeQuery       | ShortRun   | 3              | 1           | 3           | 0.1        | 1000          |  4.591 μs | 0.2417 μs | 0.0132 μs |  1.00 |    0.00 |  0.2213 |     952 B |        1.00 |
| LuceneNet_NumericRangeQuery | ShortRun   | 3              | 1           | 3           | 0.1        | 1000          | 16.560 μs | 1.1044 μs | 0.0605 μs |  3.61 |    0.01 | 12.8174 |   53880 B |       56.60 |
|                             |            |                |             |             |            |               |           |           |           |       |         |         |           |             |
| **LeanCorpus_RangeQuery**       | **DefaultJob** | **Default**        | **Default**     | **Default**     | **0.5**        | **1000**          | **10.194 μs** | **0.0137 μs** | **0.0122 μs** |  **1.00** |    **0.00** |  **0.2136** |     **952 B** |        **1.00** |
| LuceneNet_NumericRangeQuery | DefaultJob | Default        | Default     | Default     | 0.5        | 1000          | 28.190 μs | 0.0673 μs | 0.0596 μs |  2.77 |    0.01 | 13.8855 |   58312 B |       61.25 |
|                             |            |                |             |             |            |               |           |           |           |       |         |         |           |             |
| LeanCorpus_RangeQuery       | ShortRun   | 3              | 1           | 3           | 0.5        | 1000          | 10.204 μs | 0.1754 μs | 0.0096 μs |  1.00 |    0.00 |  0.2136 |     952 B |        1.00 |
| LuceneNet_NumericRangeQuery | ShortRun   | 3              | 1           | 3           | 0.5        | 1000          | 28.466 μs | 0.9019 μs | 0.0494 μs |  2.79 |    0.00 | 13.8855 |   58312 B |       61.25 |

## regexp

| Method                 | Job        | IterationCount | LaunchCount | WarmupCount | Pattern    | DocumentCount | Mean       | Error      | StdDev    | Ratio  | RatioSD | Gen0    | Gen1    | Allocated | Alloc Ratio |
|----------------------- |----------- |--------------- |------------ |------------ |----------- |-------------- |-----------:|-----------:|----------:|-------:|--------:|--------:|--------:|----------:|------------:|
| **LeanCorpus_RegexpQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **.*nation.*** | **1000**          | **401.717 μs** |  **1.2502 μs** | **1.0440 μs** |   **1.00** |    **0.00** |  **0.4883** |       **-** |    **2.7 KB** |        **1.00** |
| LuceneNet_RegexpQuery  | DefaultJob | Default        | Default     | Default     | .*nation.* | 1000          | 565.098 μs |  1.1105 μs | 0.9274 μs |   1.41 |    0.00 | 98.6328 | 13.6719 | 405.84 KB |      150.14 |
|                        |            |                |             |             |            |               |            |            |           |        |         |         |         |           |             |
| LeanCorpus_RegexpQuery | ShortRun   | 3              | 1           | 3           | .*nation.* | 1000          | 398.339 μs | 19.5643 μs | 1.0724 μs |   1.00 |    0.00 |  0.4883 |       - |    2.7 KB |        1.00 |
| LuceneNet_RegexpQuery  | ShortRun   | 3              | 1           | 3           | .*nation.* | 1000          | 567.996 μs | 63.6046 μs | 3.4864 μs |   1.43 |    0.01 | 98.6328 | 13.6719 | 405.84 KB |      150.14 |
|                        |            |                |             |             |            |               |            |            |           |        |         |         |         |           |             |
| **LeanCorpus_RegexpQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **gov.*ment**  | **1000**          |   **1.828 μs** |  **0.0038 μs** | **0.0035 μs** |   **1.00** |    **0.00** |  **0.5531** |       **-** |   **2.27 KB** |        **1.00** |
| LuceneNet_RegexpQuery  | DefaultJob | Default        | Default     | Default     | gov.*ment  | 1000          | 268.643 μs |  0.8984 μs | 0.8404 μs | 146.92 |    0.52 | 94.2383 | 14.6484 | 386.13 KB |      170.43 |
|                        |            |                |             |             |            |               |            |            |           |        |         |         |         |           |             |
| LeanCorpus_RegexpQuery | ShortRun   | 3              | 1           | 3           | gov.*ment  | 1000          |   1.955 μs |  0.0687 μs | 0.0038 μs |   1.00 |    0.00 |  0.5531 |       - |   2.27 KB |        1.00 |
| LuceneNet_RegexpQuery  | ShortRun   | 3              | 1           | 3           | gov.*ment  | 1000          | 268.505 μs |  9.3736 μs | 0.5138 μs | 137.33 |    0.32 | 94.2383 | 14.6484 | 386.13 KB |      170.43 |
|                        |            |                |             |             |            |               |            |            |           |        |         |         |         |           |             |
| **LeanCorpus_RegexpQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **mark.***     | **1000**          |   **3.947 μs** |  **0.0113 μs** | **0.0100 μs** |   **1.00** |    **0.00** |  **0.9232** |       **-** |   **3.77 KB** |        **1.00** |
| LuceneNet_RegexpQuery  | DefaultJob | Default        | Default     | Default     | mark.*     | 1000          |  51.990 μs |  0.1106 μs | 0.1035 μs |  13.17 |    0.04 | 24.8413 |       - | 101.66 KB |       26.94 |
|                        |            |                |             |             |            |               |            |            |           |        |         |         |         |           |             |
| LeanCorpus_RegexpQuery | ShortRun   | 3              | 1           | 3           | mark.*     | 1000          |   3.982 μs |  0.1658 μs | 0.0091 μs |   1.00 |    0.00 |  0.9232 |       - |   3.77 KB |        1.00 |
| LuceneNet_RegexpQuery  | ShortRun   | 3              | 1           | 3           | mark.*     | 1000          |  51.536 μs |  1.9995 μs | 0.1096 μs |  12.94 |    0.03 | 24.8413 |       - | 101.66 KB |       26.94 |

## Schema and JSON

| Method                      | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean      | Error      | StdDev    | Median    | Ratio | RatioSD | Gen0      | Gen1     | Allocated  | Alloc Ratio |
|---------------------------- |----------- |--------------- |------------ |------------ |-------------- |----------:|-----------:|----------:|----------:|------:|--------:|----------:|---------:|-----------:|------------:|
| LeanCorpus_Index_NoSchema   | DefaultJob | Default        | Default     | Default     | 1000          | 36.601 ms |  0.7315 ms | 1.7666 ms | 35.268 ms |  1.00 |    0.00 | 1000.0000 | 928.5714 | 8119.79 KB |        1.00 |
| LeanCorpus_Index_WithSchema | DefaultJob | Default        | Default     | Default     | 1000          | 37.325 ms |  0.7463 ms | 1.1397 ms | 36.664 ms |  1.02 |    0.06 | 1000.0000 | 928.5714 | 8159.18 KB |        1.00 |
| LeanCorpus_JsonMapping      | DefaultJob | Default        | Default     | Default     | 1000          |  2.181 ms |  0.0076 ms | 0.0071 ms |  2.181 ms |  0.06 |    0.00 |  234.3750 |        - |  960.37 KB |        0.12 |
|                             |            |                |             |             |               |           |            |           |           |       |         |           |          |            |             |
| LeanCorpus_Index_NoSchema   | ShortRun   | 3              | 1           | 3           | 1000          | 36.868 ms | 34.2591 ms | 1.8779 ms | 37.753 ms |  1.00 |    0.00 |  928.5714 | 214.2857 | 8118.56 KB |        1.00 |
| LeanCorpus_Index_WithSchema | ShortRun   | 3              | 1           | 3           | 1000          | 36.583 ms | 22.1867 ms | 1.2161 ms | 35.958 ms |  0.99 |    0.05 | 1000.0000 | 928.5714 | 8159.19 KB |        1.01 |
| LeanCorpus_JsonMapping      | ShortRun   | 3              | 1           | 3           | 1000          |  2.169 ms |  0.0737 ms | 0.0040 ms |  2.170 ms |  0.06 |    0.00 |  234.3750 |        - |  960.37 KB |        0.12 |

## searcher-mgr

| Method                                   | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean       | Error     | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |----------- |--------------- |------------ |------------ |-------------- |-----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| LeanCorpus_SearcherManager_AcquireSearch | DefaultJob | Default        | Default     | Default     | 1000          |   338.8 ns |   0.83 ns |  0.78 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearcherManager_AcquireLease  | DefaultJob | Default        | Default     | Default     | 1000          |   327.6 ns |   0.67 ns |  0.60 ns |  0.97 |    0.00 | 0.0763 |     320 B |        1.25 |
| LuceneNet_SearcherManager_AcquireSearch  | DefaultJob | Default        | Default     | Default     | 1000          | 2,987.9 ns |  14.22 ns | 13.31 ns |  8.82 |    0.04 | 2.0409 |    8544 B |       33.38 |
|                                          |            |                |             |             |               |            |           |          |       |         |        |           |             |
| LeanCorpus_SearcherManager_AcquireSearch | ShortRun   | 3              | 1           | 3           | 1000          |   335.4 ns |  18.95 ns |  1.04 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_SearcherManager_AcquireLease  | ShortRun   | 3              | 1           | 3           | 1000          |   325.0 ns |  12.63 ns |  0.69 ns |  0.97 |    0.00 | 0.0763 |     320 B |        1.25 |
| LuceneNet_SearcherManager_AcquireSearch  | ShortRun   | 3              | 1           | 3           | 1000          | 2,914.0 ns | 224.40 ns | 12.30 ns |  8.69 |    0.04 | 2.0409 |    8544 B |       33.38 |

## similarity

| Method                        | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean       | Error    | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |----------- |--------------- |------------ |------------ |-------------- |-----------:|---------:|--------:|------:|--------:|-------:|----------:|------------:|
| LeanCorpus_Bm25_TermQuery     | DefaultJob | Default        | Default     | Default     | 1000          |   306.7 ns |  0.75 ns | 0.70 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_TfIdf_TermQuery    | DefaultJob | Default        | Default     | Default     | 1000          |   304.6 ns |  0.62 ns | 0.58 ns |  0.99 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_Bm25_BooleanQuery  | DefaultJob | Default        | Default     | Default     | 1000          | 1,467.4 ns |  3.02 ns | 2.82 ns |  4.78 |    0.01 | 0.4616 |    1936 B |        7.56 |
| LeanCorpus_TfIdf_BooleanQuery | DefaultJob | Default        | Default     | Default     | 1000          | 1,418.4 ns |  2.88 ns | 2.55 ns |  4.62 |    0.01 | 0.4616 |    1936 B |        7.56 |
|                               |            |                |             |             |               |            |          |         |       |         |        |           |             |
| LeanCorpus_Bm25_TermQuery     | ShortRun   | 3              | 1           | 3           | 1000          |   304.6 ns |  9.78 ns | 0.54 ns |  1.00 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_TfIdf_TermQuery    | ShortRun   | 3              | 1           | 3           | 1000          |   316.1 ns | 12.25 ns | 0.67 ns |  1.04 |    0.00 | 0.0610 |     256 B |        1.00 |
| LeanCorpus_Bm25_BooleanQuery  | ShortRun   | 3              | 1           | 3           | 1000          | 1,505.8 ns | 87.01 ns | 4.77 ns |  4.94 |    0.02 | 0.4616 |    1936 B |        7.56 |
| LeanCorpus_TfIdf_BooleanQuery | ShortRun   | 3              | 1           | 3           | 1000          | 1,608.2 ns | 75.31 ns | 4.13 ns |  5.28 |    0.01 | 0.4616 |    1936 B |        7.56 |

## span

| Method               | Job        | IterationCount | LaunchCount | WarmupCount | SpanType | DocumentCount | Mean        | Error       | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------- |----------- |--------------- |------------ |------------ |--------- |-------------- |------------:|------------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| **LeanCorpus_SpanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Near**     | **1000**          |    **467.6 ns** |     **0.96 ns** |  **0.85 ns** |  **1.00** |    **0.00** | **0.2770** |      **-** |   **1.13 KB** |        **1.00** |
| LuceneNet_SpanQuery  | DefaultJob | Default        | Default     | Default     | Near     | 1000          |  8,466.7 ns |    25.91 ns | 24.24 ns | 18.11 |    0.06 | 5.0964 |      - |  20.83 KB |       18.39 |
|                      |            |                |             |             |          |               |             |             |          |       |         |        |        |           |             |
| LeanCorpus_SpanQuery | ShortRun   | 3              | 1           | 3           | Near     | 1000          |    487.6 ns |    18.61 ns |  1.02 ns |  1.00 |    0.00 | 0.2766 |      - |   1.13 KB |        1.00 |
| LuceneNet_SpanQuery  | ShortRun   | 3              | 1           | 3           | Near     | 1000          |  8,477.9 ns |   560.38 ns | 30.72 ns | 17.39 |    0.06 | 5.0964 |      - |  20.83 KB |       18.39 |
|                      |            |                |             |             |          |               |             |             |          |       |         |        |        |           |             |
| **LeanCorpus_SpanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Not**      | **1000**          |    **714.3 ns** |     **2.47 ns** |  **2.31 ns** |  **1.00** |    **0.00** | **0.2975** |      **-** |   **1.22 KB** |        **1.00** |
| LuceneNet_SpanQuery  | DefaultJob | Default        | Default     | Default     | Not      | 1000          | 10,858.0 ns |    21.81 ns | 19.33 ns | 15.20 |    0.05 | 6.6071 |      - |  27.04 KB |       22.19 |
|                      |            |                |             |             |          |               |             |             |          |       |         |        |        |           |             |
| LeanCorpus_SpanQuery | ShortRun   | 3              | 1           | 3           | Not      | 1000          |    734.9 ns |    36.79 ns |  2.02 ns |  1.00 |    0.00 | 0.2975 |      - |   1.22 KB |        1.00 |
| LuceneNet_SpanQuery  | ShortRun   | 3              | 1           | 3           | Not      | 1000          | 11,065.5 ns |   333.20 ns | 18.26 ns | 15.06 |    0.04 | 6.6071 |      - |  27.04 KB |       22.19 |
|                      |            |                |             |             |          |               |             |             |          |       |         |        |        |           |             |
| **LeanCorpus_SpanQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **Or**       | **1000**          |  **1,527.6 ns** |     **3.08 ns** |  **2.73 ns** |  **1.00** |    **0.00** | **0.2556** |      **-** |   **1.05 KB** |        **1.00** |
| LuceneNet_SpanQuery  | DefaultJob | Default        | Default     | Default     | Or       | 1000          | 15,896.3 ns |    48.18 ns | 45.07 ns | 10.41 |    0.03 | 7.2021 | 0.0305 |  29.52 KB |       28.19 |
|                      |            |                |             |             |          |               |             |             |          |       |         |        |        |           |             |
| LeanCorpus_SpanQuery | ShortRun   | 3              | 1           | 3           | Or       | 1000          |  1,582.9 ns |    78.04 ns |  4.28 ns |  1.00 |    0.00 | 0.2556 |      - |   1.05 KB |        1.00 |
| LuceneNet_SpanQuery  | ShortRun   | 3              | 1           | 3           | Or       | 1000          | 16,108.0 ns | 1,093.75 ns | 59.95 ns | 10.18 |    0.04 | 7.2021 | 0.0305 |  29.52 KB |       28.19 |

## stemmer

| Method                     | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0     | Allocated  | Alloc Ratio |
|--------------------------- |----------- |--------------- |------------ |------------ |-------------- |---------:|----------:|----------:|------:|---------:|-----------:|------------:|
| LeanCorpus_StemmedAnalyser | DefaultJob | Default        | Default     | Default     | 1000          | 7.436 ms | 0.0143 ms | 0.0134 ms |  1.00 |  93.7500 |   389.6 KB |        1.00 |
| LuceneNet_EnglishAnalyzer  | DefaultJob | Default        | Default     | Default     | 1000          | 9.549 ms | 0.0269 ms | 0.0252 ms |  1.28 | 390.6250 | 1622.99 KB |        4.17 |
|                            |            |                |             |             |               |          |           |           |       |          |            |             |
| LeanCorpus_StemmedAnalyser | ShortRun   | 3              | 1           | 3           | 1000          | 7.766 ms | 0.1504 ms | 0.0082 ms |  1.00 |  93.7500 |   389.6 KB |        1.00 |
| LuceneNet_EnglishAnalyzer  | ShortRun   | 3              | 1           | 3           | 1000          | 9.578 ms | 0.4670 ms | 0.0256 ms |  1.23 | 390.6250 | 1622.99 KB |        4.17 |

## Suggester

| Method                 | Job        | IterationCount | LaunchCount | WarmupCount | DocumentCount | Mean       | Error     | StdDev   | Ratio | RatioSD | Gen0      | Gen1    | Allocated  | Alloc Ratio |
|----------------------- |----------- |--------------- |------------ |------------ |-------------- |-----------:|----------:|---------:|------:|--------:|----------:|--------:|-----------:|------------:|
| LeanCorpus_DidYouMean  | DefaultJob | Default        | Default     | Default     | 1000          |   202.3 μs |   0.33 μs |  0.29 μs |  1.00 |    0.00 |    1.7090 |       - |     7.5 KB |        1.00 |
| LeanCorpus_SpellIndex  | DefaultJob | Default        | Default     | Default     | 1000          |   221.3 μs |   0.46 μs |  0.43 μs |  1.09 |    0.00 |    1.2207 |       - |    5.78 KB |        0.77 |
| LuceneNet_SpellChecker | DefaultJob | Default        | Default     | Default     | 1000          | 6,150.2 μs |  15.55 μs | 14.55 μs | 30.41 |    0.08 | 1195.3125 | 15.6250 | 4906.45 KB |      654.19 |
|                        |            |                |             |             |               |            |           |          |       |         |           |         |            |             |
| LeanCorpus_DidYouMean  | ShortRun   | 3              | 1           | 3           | 1000          |   205.2 μs |  10.17 μs |  0.56 μs |  1.00 |    0.00 |    1.7090 |       - |     7.5 KB |        1.00 |
| LeanCorpus_SpellIndex  | ShortRun   | 3              | 1           | 3           | 1000          |   200.0 μs |   5.81 μs |  0.32 μs |  0.97 |    0.00 |    1.2207 |       - |    5.78 KB |        0.77 |
| LuceneNet_SpellChecker | ShortRun   | 3              | 1           | 3           | 1000          | 6,359.8 μs | 185.02 μs | 10.14 μs | 30.99 |    0.08 | 1195.3125 | 15.6250 | 4906.45 KB |      654.19 |

## synonym

| Method                  | Job        | IterationCount | LaunchCount | WarmupCount | SynonymCount | DocumentCount | Mean     | Error     | StdDev    | Ratio | Gen0      | Allocated  | Alloc Ratio |
|------------------------ |----------- |--------------- |------------ |------------ |------------- |-------------- |---------:|----------:|----------:|------:|----------:|-----------:|------------:|
| **LeanCorpus_NoSynonyms**   | **DefaultJob** | **Default**        | **Default**     | **Default**     | **10**           | **1000**          | **4.390 ms** | **0.0092 ms** | **0.0086 ms** |  **1.00** |    **7.8125** |   **45.31 KB** |        **1.00** |
| LeanCorpus_WithSynonyms | DefaultJob | Default        | Default     | Default     | 10           | 1000          | 6.648 ms | 0.0125 ms | 0.0117 ms |  1.51 |  890.6250 | 3660.93 KB |       80.79 |
|                         |            |                |             |             |              |               |          |           |           |       |           |            |             |
| LeanCorpus_NoSynonyms   | ShortRun   | 3              | 1           | 3           | 10           | 1000          | 4.058 ms | 0.2371 ms | 0.0130 ms |  1.00 |    7.8125 |   45.31 KB |        1.00 |
| LeanCorpus_WithSynonyms | ShortRun   | 3              | 1           | 3           | 10           | 1000          | 6.585 ms | 0.3633 ms | 0.0199 ms |  1.62 |  890.6250 | 3660.93 KB |       80.79 |
|                         |            |                |             |             |              |               |          |           |           |       |           |            |             |
| **LeanCorpus_NoSynonyms**   | **DefaultJob** | **Default**        | **Default**     | **Default**     | **50**           | **1000**          | **4.059 ms** | **0.0088 ms** | **0.0074 ms** |  **1.00** |    **7.8125** |   **45.31 KB** |        **1.00** |
| LeanCorpus_WithSynonyms | DefaultJob | Default        | Default     | Default     | 50           | 1000          | 6.790 ms | 0.0090 ms | 0.0071 ms |  1.67 | 1000.0000 | 4109.45 KB |       90.69 |
|                         |            |                |             |             |              |               |          |           |           |       |           |            |             |
| LeanCorpus_NoSynonyms   | ShortRun   | 3              | 1           | 3           | 50           | 1000          | 4.335 ms | 0.1321 ms | 0.0072 ms |  1.00 |    7.8125 |   45.31 KB |        1.00 |
| LeanCorpus_WithSynonyms | ShortRun   | 3              | 1           | 3           | 50           | 1000          | 6.946 ms | 0.3456 ms | 0.0189 ms |  1.60 | 1000.0000 | 4109.45 KB |       90.69 |
|                         |            |                |             |             |              |               |          |           |           |       |           |            |             |
| **LeanCorpus_NoSynonyms**   | **DefaultJob** | **Default**        | **Default**     | **Default**     | **200**          | **1000**          | **4.246 ms** | **0.0107 ms** | **0.0100 ms** |  **1.00** |    **7.8125** |   **45.31 KB** |        **1.00** |
| LeanCorpus_WithSynonyms | DefaultJob | Default        | Default     | Default     | 200          | 1000          | 7.239 ms | 0.0141 ms | 0.0118 ms |  1.70 | 1421.8750 |  5826.8 KB |      128.59 |
|                         |            |                |             |             |              |               |          |           |           |       |           |            |             |
| LeanCorpus_NoSynonyms   | ShortRun   | 3              | 1           | 3           | 200          | 1000          | 4.077 ms | 0.0796 ms | 0.0044 ms |  1.00 |    7.8125 |   45.31 KB |        1.00 |
| LeanCorpus_WithSynonyms | ShortRun   | 3              | 1           | 3           | 200          | 1000          | 7.292 ms | 0.6253 ms | 0.0343 ms |  1.79 | 1421.8750 |  5826.8 KB |      128.59 |

## terminset

| Method                         | Job        | IterationCount | LaunchCount | WarmupCount | SetSize | DocumentCount | Mean      | Error    | StdDev   | Ratio | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------------- |----------- |--------------- |------------ |------------ |-------- |-------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_TermInSetQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **5**       | **1000**          |  **10.80 μs** | **0.021 μs** | **0.020 μs** |  **1.00** |  **0.3510** |      **-** |   **1.48 KB** |        **1.00** |
| LeanCorpus_BooleanQuery_Should | DefaultJob | Default        | Default     | Default     | 5       | 1000          |  22.06 μs | 0.041 μs | 0.038 μs |  2.04 |  0.7935 |      - |   3.29 KB |        2.22 |
|                                |            |                |             |             |         |               |           |          |          |       |         |        |           |             |
| LeanCorpus_TermInSetQuery      | ShortRun   | 3              | 1           | 3           | 5       | 1000          |  10.73 μs | 0.479 μs | 0.026 μs |  1.00 |  0.3510 |      - |   1.48 KB |        1.00 |
| LeanCorpus_BooleanQuery_Should | ShortRun   | 3              | 1           | 3           | 5       | 1000          |  21.86 μs | 1.412 μs | 0.077 μs |  2.04 |  0.7935 |      - |   3.29 KB |        2.22 |
|                                |            |                |             |             |         |               |           |          |          |       |         |        |           |             |
| **LeanCorpus_TermInSetQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **20**      | **1000**          |  **19.26 μs** | **0.025 μs** | **0.021 μs** |  **1.00** |  **0.7629** |      **-** |   **3.15 KB** |        **1.00** |
| LeanCorpus_BooleanQuery_Should | DefaultJob | Default        | Default     | Default     | 20      | 1000          |  48.29 μs | 0.150 μs | 0.140 μs |  2.51 |  2.3193 |      - |   9.66 KB |        3.07 |
|                                |            |                |             |             |         |               |           |          |          |       |         |        |           |             |
| LeanCorpus_TermInSetQuery      | ShortRun   | 3              | 1           | 3           | 20      | 1000          |  18.84 μs | 1.265 μs | 0.069 μs |  1.00 |  0.7629 |      - |   3.15 KB |        1.00 |
| LeanCorpus_BooleanQuery_Should | ShortRun   | 3              | 1           | 3           | 20      | 1000          |  47.69 μs | 1.569 μs | 0.086 μs |  2.53 |  2.3193 |      - |   9.66 KB |        3.07 |
|                                |            |                |             |             |         |               |           |          |          |       |         |        |           |             |
| **LeanCorpus_TermInSetQuery**      | **DefaultJob** | **Default**        | **Default**     | **Default**     | **100**     | **1000**          |  **45.13 μs** | **0.100 μs** | **0.094 μs** |  **1.00** |  **2.8687** |      **-** |  **11.76 KB** |        **1.00** |
| LeanCorpus_BooleanQuery_Should | DefaultJob | Default        | Default     | Default     | 100     | 1000          | 183.53 μs | 0.366 μs | 0.342 μs |  4.07 | 10.2539 | 0.7324 |  42.84 KB |        3.64 |
|                                |            |                |             |             |         |               |           |          |          |       |         |        |           |             |
| LeanCorpus_TermInSetQuery      | ShortRun   | 3              | 1           | 3           | 100     | 1000          |  47.29 μs | 1.136 μs | 0.062 μs |  1.00 |  2.8687 |      - |  11.76 KB |        1.00 |
| LeanCorpus_BooleanQuery_Should | ShortRun   | 3              | 1           | 3           | 100     | 1000          | 183.89 μs | 5.753 μs | 0.315 μs |  3.89 | 10.2539 | 0.7324 |  42.84 KB |        3.64 |

## Wildcard queries

| Method                   | Job        | IterationCount | LaunchCount | WarmupCount | WildcardPattern | DocumentCount | Mean         | Error       | StdDev    | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------- |----------- |--------------- |------------ |------------ |---------------- |-------------- |-------------:|------------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **LeanCorpus_WildcardQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **gov***            | **1000**          |     **520.7 ns** |     **1.61 ns** |   **1.50 ns** |  **1.00** |    **0.00** |  **0.1335** |      **-** |     **560 B** |        **1.00** |
| LuceneNet_WildcardQuery  | DefaultJob | Default        | Default     | Default     | gov*            | 1000          |  40,614.9 ns |   114.10 ns | 106.73 ns | 78.00 |    0.29 | 34.4238 | 6.8970 |  144576 B |      258.17 |
|                          |            |                |             |             |                 |               |              |             |           |       |         |         |        |           |             |
| LeanCorpus_WildcardQuery | ShortRun   | 3              | 1           | 3           | gov*            | 1000          |     498.6 ns |    28.11 ns |   1.54 ns |  1.00 |    0.00 |  0.1335 |      - |     560 B |        1.00 |
| LuceneNet_WildcardQuery  | ShortRun   | 3              | 1           | 3           | gov*            | 1000          |  40,747.6 ns | 2,888.56 ns | 158.33 ns | 81.72 |    0.35 | 34.4238 | 6.8970 |  144576 B |      258.17 |
|                          |            |                |             |             |                 |               |              |             |           |       |         |         |        |           |             |
| **LeanCorpus_WildcardQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **m*rket**          | **1000**          |  **12,599.9 ns** |    **24.39 ns** |  **22.82 ns** |  **1.00** |    **0.00** |  **0.1221** |      **-** |     **520 B** |        **1.00** |
| LuceneNet_WildcardQuery  | DefaultJob | Default        | Default     | Default     | m*rket          | 1000          | 207,641.4 ns |   500.95 ns | 468.59 ns | 16.48 |    0.05 | 84.2285 | 1.2207 |  352952 B |      678.75 |
|                          |            |                |             |             |                 |               |              |             |           |       |         |         |        |           |             |
| LeanCorpus_WildcardQuery | ShortRun   | 3              | 1           | 3           | m*rket          | 1000          |  12,691.7 ns |   633.41 ns |  34.72 ns |  1.00 |    0.00 |  0.1221 |      - |     520 B |        1.00 |
| LuceneNet_WildcardQuery  | ShortRun   | 3              | 1           | 3           | m*rket          | 1000          | 206,692.7 ns | 7,753.83 ns | 425.01 ns | 16.29 |    0.05 | 84.2285 | 1.2207 |  352952 B |      678.75 |
|                          |            |                |             |             |                 |               |              |             |           |       |         |         |        |           |             |
| **LeanCorpus_WildcardQuery** | **DefaultJob** | **Default**        | **Default**     | **Default**     | **pre*dent**        | **1000**          |   **3,043.4 ns** |     **4.22 ns** |   **3.53 ns** |  **1.00** |    **0.00** |  **0.1221** |      **-** |     **520 B** |        **1.00** |
| LuceneNet_WildcardQuery  | DefaultJob | Default        | Default     | Default     | pre*dent        | 1000          | 229,208.8 ns |   555.38 ns | 519.50 ns | 75.31 |    0.19 | 88.6230 | 0.9766 |  370816 B |      713.11 |
|                          |            |                |             |             |                 |               |              |             |           |       |         |         |        |           |             |
| LeanCorpus_WildcardQuery | ShortRun   | 3              | 1           | 3           | pre*dent        | 1000          |   3,226.9 ns |   100.10 ns |   5.49 ns |  1.00 |    0.00 |  0.1221 |      - |     520 B |        1.00 |
| LuceneNet_WildcardQuery  | ShortRun   | 3              | 1           | 3           | pre*dent        | 1000          | 228,792.6 ns | 5,454.45 ns | 298.98 ns | 70.90 |    0.13 | 88.6230 | 0.9766 |  370816 B |      713.11 |

<details>
<summary>Full data (report.json)</summary>

<pre><code class="lang-json">{
  "schemaVersion": 2,
  "runId": "2026-05-22 13-26 (3e35ed58)",
  "runType": "full",
  "generatedAtUtc": "2026-05-22T13:26:29.6073315\u002B00:00",
  "commandLineArgs": [
    "--job",
    "short"
  ],
  "hostMachineName": "debian",
  "commitHash": "3e35ed58",
  "dotnetVersion": "10.0.3",
  "provenance": {
    "sourceCommit": "3e35ed58",
    "sourceRef": "",
    "sourceManifestPath": "",
    "gitCommitHash": "3e35ed58",
    "gitAvailable": true,
    "gitDirty": false,
    "benchmarkDotNetVersion": "0.16.0-nightly.20260427.506\u002Bc68dc1556c410c4bdfe21373c7689be5781fbaf9",
    "runtimeFramework": ".NET 10.0.3",
    "runtimeIdentifier": "linux-x64",
    "osDescription": "Debian GNU/Linux 13 (trixie)",
    "processArchitecture": "X64",
    "effectiveDocCount": 1000,
    "dataFingerprintSha256": "",
    "dataSources": []
  },
  "totalBenchmarkCount": 222,
  "suites": [
    {
      "suiteName": "aggregation",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.AggregationBenchmarks-20260522-163240",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "AggregationBenchmarks.LeanCorpus_SearchOnly|DocumentCount=1000",
          "displayInfo": "AggregationBenchmarks.LeanCorpus_SearchOnly: DefaultJob [DocumentCount=1000]",
          "typeName": "AggregationBenchmarks",
          "methodName": "LeanCorpus_SearchOnly",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 306.4251176516215,
            "medianNanoseconds": 306.48194694519043,
            "minNanoseconds": 305.63046169281006,
            "maxNanoseconds": 307.44837045669556,
            "standardDeviationNanoseconds": 0.5725048984275073,
            "operationsPerSecond": 3263440.045854571
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AggregationBenchmarks.LeanCorpus_SearchWithHistogram|DocumentCount=1000",
          "displayInfo": "AggregationBenchmarks.LeanCorpus_SearchWithHistogram: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "AggregationBenchmarks",
          "methodName": "LeanCorpus_SearchWithHistogram",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 345.72320016225177,
            "medianNanoseconds": 345.6307849884033,
            "minNanoseconds": 344.7635407447815,
            "maxNanoseconds": 346.77527475357056,
            "standardDeviationNanoseconds": 1.0090460117347029,
            "operationsPerSecond": 2892487.3989674076
          },
          "gc": {
            "bytesAllocatedPerOperation": 288,
            "gen0Collections": 144,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AggregationBenchmarks.LeanCorpus_SearchWithStatsAndHistogram|DocumentCount=1000",
          "displayInfo": "AggregationBenchmarks.LeanCorpus_SearchWithStatsAndHistogram: DefaultJob [DocumentCount=1000]",
          "typeName": "AggregationBenchmarks",
          "methodName": "LeanCorpus_SearchWithStatsAndHistogram",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 317.94084075291954,
            "medianNanoseconds": 317.91344356536865,
            "minNanoseconds": 317.06058263778687,
            "maxNanoseconds": 319.28691482543945,
            "standardDeviationNanoseconds": 0.6201991535590043,
            "operationsPerSecond": 3145239.2137854574
          },
          "gc": {
            "bytesAllocatedPerOperation": 296,
            "gen0Collections": 148,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AggregationBenchmarks.LeanCorpus_SearchWithStats|DocumentCount=1000",
          "displayInfo": "AggregationBenchmarks.LeanCorpus_SearchWithStats: DefaultJob [DocumentCount=1000]",
          "typeName": "AggregationBenchmarks",
          "methodName": "LeanCorpus_SearchWithStats",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 341.1054492337363,
            "medianNanoseconds": 341.6870858669281,
            "minNanoseconds": 335.6752219200134,
            "maxNanoseconds": 342.85400342941284,
            "standardDeviationNanoseconds": 2.093702917497837,
            "operationsPerSecond": 2931644.7516344665
          },
          "gc": {
            "bytesAllocatedPerOperation": 288,
            "gen0Collections": 144,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "analysis",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.AnalysisBenchmarks-20260522-143439",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "AnalysisBenchmarks.LeanCorpus_Analyse|DocumentCount=1000",
          "displayInfo": "AnalysisBenchmarks.LeanCorpus_Analyse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "AnalysisBenchmarks",
          "methodName": "LeanCorpus_Analyse",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 4130842.9427083335,
            "medianNanoseconds": 4132341.640625,
            "minNanoseconds": 4102316.4375,
            "maxNanoseconds": 4157870.75,
            "standardDeviationNanoseconds": 27807.46268398071,
            "operationsPerSecond": 242.08134123452368
          },
          "gc": {
            "bytesAllocatedPerOperation": 46400,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalysisBenchmarks.LuceneNet_Analyse|DocumentCount=1000",
          "displayInfo": "AnalysisBenchmarks.LuceneNet_Analyse: DefaultJob [DocumentCount=1000]",
          "typeName": "AnalysisBenchmarks",
          "methodName": "LuceneNet_Analyse",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 6311029.973214285,
            "medianNanoseconds": 6310309.37890625,
            "minNanoseconds": 6289985.140625,
            "maxNanoseconds": 6341084.96875,
            "standardDeviationNanoseconds": 16644.277822675012,
            "operationsPerSecond": 158.45274135034532
          },
          "gc": {
            "bytesAllocatedPerOperation": 1700464,
            "gen0Collections": 52,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "analysis-filters",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.TokenFilterBenchmarks-20260522-144032",
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
            "meanNanoseconds": 153.87455296516418,
            "medianNanoseconds": 153.97111082077026,
            "minNanoseconds": 153.50248265266418,
            "maxNanoseconds": 154.29985737800598,
            "standardDeviationNanoseconds": 0.27089165109807667,
            "operationsPerSecond": 6498800.358668733
          },
          "gc": {
            "bytesAllocatedPerOperation": 168,
            "gen0Collections": 168,
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
            "sampleCount": 13,
            "meanNanoseconds": 213.82127996591421,
            "medianNanoseconds": 213.71457600593567,
            "minNanoseconds": 213.12244081497192,
            "maxNanoseconds": 214.52609086036682,
            "standardDeviationNanoseconds": 0.39655876649121263,
            "operationsPerSecond": 4676802.983124096
          },
          "gc": {
            "bytesAllocatedPerOperation": 200,
            "gen0Collections": 200,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=length-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=length-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "length-mutating"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 120.90164732933044,
            "medianNanoseconds": 120.86632037162781,
            "minNanoseconds": 120.71615600585938,
            "maxNanoseconds": 121.12246561050415,
            "standardDeviationNanoseconds": 0.20544553818966557,
            "operationsPerSecond": 8271185.894399326
          },
          "gc": {
            "bytesAllocatedPerOperation": 176,
            "gen0Collections": 176,
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
            "sampleCount": 15,
            "meanNanoseconds": 103.1279891093572,
            "medianNanoseconds": 103.1359726190567,
            "minNanoseconds": 102.91128706932068,
            "maxNanoseconds": 103.46911990642548,
            "standardDeviationNanoseconds": 0.18150553523571045,
            "operationsPerSecond": 9696688.63551288
          },
          "gc": {
            "bytesAllocatedPerOperation": 176,
            "gen0Collections": 353,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=reverse-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=reverse-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "reverse-mutating"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 138.97905286153158,
            "medianNanoseconds": 138.92548966407776,
            "minNanoseconds": 138.84561395645142,
            "maxNanoseconds": 139.16605496406555,
            "standardDeviationNanoseconds": 0.16680039547704337,
            "operationsPerSecond": 7195328.932024928
          },
          "gc": {
            "bytesAllocatedPerOperation": 208,
            "gen0Collections": 208,
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
            "sampleCount": 14,
            "meanNanoseconds": 392.3180956840515,
            "medianNanoseconds": 392.3539710044861,
            "minNanoseconds": 391.58626985549927,
            "maxNanoseconds": 393.04199600219727,
            "standardDeviationNanoseconds": 0.43967262888987163,
            "operationsPerSecond": 2548952.0136877336
          },
          "gc": {
            "bytesAllocatedPerOperation": 864,
            "gen0Collections": 433,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=truncate-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=truncate-mutating]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "truncate-mutating"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 116.30796551704407,
            "medianNanoseconds": 116.20702350139618,
            "minNanoseconds": 115.86670732498169,
            "maxNanoseconds": 116.85016572475433,
            "standardDeviationNanoseconds": 0.49943925948320916,
            "operationsPerSecond": 8597863.40131156
          },
          "gc": {
            "bytesAllocatedPerOperation": 176,
            "gen0Collections": 353,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=truncate-noop",
          "displayInfo": "TokenFilterBenchmarks.Apply: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=truncate-noop]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "truncate-noop"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 102.12268435955048,
            "medianNanoseconds": 101.99869501590729,
            "minNanoseconds": 101.86930418014526,
            "maxNanoseconds": 102.50005388259888,
            "standardDeviationNanoseconds": 0.33315359038907555,
            "operationsPerSecond": 9792143.697273273
          },
          "gc": {
            "bytesAllocatedPerOperation": 176,
            "gen0Collections": 353,
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
            "sampleCount": 15,
            "meanNanoseconds": 222.3874584197998,
            "medianNanoseconds": 222.41879796981812,
            "minNanoseconds": 221.67195343971252,
            "maxNanoseconds": 223.11139845848083,
            "standardDeviationNanoseconds": 0.44497912093237757,
            "operationsPerSecond": 4496656.45313642
          },
          "gc": {
            "bytesAllocatedPerOperation": 392,
            "gen0Collections": 393,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TokenFilterBenchmarks.Apply|Scenario=word-delimiter-mutating",
          "displayInfo": "TokenFilterBenchmarks.Apply: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=word-(...)ating [23]]",
          "typeName": "TokenFilterBenchmarks",
          "methodName": "Apply",
          "parameters": {
            "Scenario": "word-delimiter-mutating"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 586.8949762980143,
            "medianNanoseconds": 586.4823703765869,
            "minNanoseconds": 585.7081069946289,
            "maxNanoseconds": 588.4944515228271,
            "standardDeviationNanoseconds": 1.4382669057768076,
            "operationsPerSecond": 1703882.3646229657
          },
          "gc": {
            "bytesAllocatedPerOperation": 1432,
            "gen0Collections": 359,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "analysis-parity",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.AnalyserParityBenchmarks-20260522-143651",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "AnalyserParityBenchmarks.LeanCorpus_Keyword",
          "displayInfo": "AnalyserParityBenchmarks.LeanCorpus_Keyword: DefaultJob",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanCorpus_Keyword",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 4093.5554514567057,
            "medianNanoseconds": 4094.487236022949,
            "minNanoseconds": 4086.3616104125977,
            "maxNanoseconds": 4100.78670501709,
            "standardDeviationNanoseconds": 4.955771605958312,
            "operationsPerSecond": 244286.41845907978
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LeanCorpus_Simple",
          "displayInfo": "AnalyserParityBenchmarks.LeanCorpus_Simple: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanCorpus_Simple",
          "parameters": {},
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 41885.188720703125,
            "medianNanoseconds": 41863.69519042969,
            "minNanoseconds": 41854.036376953125,
            "maxNanoseconds": 41937.83459472656,
            "standardDeviationNanoseconds": 45.84772849566808,
            "operationsPerSecond": 23874.78797500839
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "AnalyserParityBenchmarks.LeanCorpus_Whitespace",
          "displayInfo": "AnalyserParityBenchmarks.LeanCorpus_Whitespace: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LeanCorpus_Whitespace",
          "parameters": {},
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 48106.11934407552,
            "medianNanoseconds": 48079.93359375,
            "minNanoseconds": 48068.88494873047,
            "maxNanoseconds": 48169.539489746094,
            "standardDeviationNanoseconds": 55.200582395926034,
            "operationsPerSecond": 20787.376193194315
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
            "meanNanoseconds": 11950.905615234375,
            "medianNanoseconds": 11953.753479003906,
            "minNanoseconds": 11929.761245727539,
            "maxNanoseconds": 11981.95571899414,
            "standardDeviationNanoseconds": 16.305444950312417,
            "operationsPerSecond": 83675.66711641112
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
            "meanNanoseconds": 81992.82070486886,
            "medianNanoseconds": 81954.95593261719,
            "minNanoseconds": 81874.00573730469,
            "maxNanoseconds": 82184.95532226562,
            "standardDeviationNanoseconds": 106.54369182780174,
            "operationsPerSecond": 12196.189756655345
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
          "displayInfo": "AnalyserParityBenchmarks.LuceneNet_Whitespace: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)",
          "typeName": "AnalyserParityBenchmarks",
          "methodName": "LuceneNet_Whitespace",
          "parameters": {},
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 73618.60461425781,
            "medianNanoseconds": 73633.02038574219,
            "minNanoseconds": 73507.47436523438,
            "maxNanoseconds": 73715.31909179688,
            "standardDeviationNanoseconds": 104.66956788186998,
            "operationsPerSecond": 13583.52287767118
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
      "suiteName": "async-index",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.AsyncIndexingBenchmarks-20260522-172207",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "AsyncIndexingBenchmarks.LeanCorpus_AddDocumentAsync_Sequential|DocumentCount=1000",
          "displayInfo": "AsyncIndexingBenchmarks.LeanCorpus_AddDocumentAsync_Sequential: DefaultJob [DocumentCount=1000]",
          "typeName": "AsyncIndexingBenchmarks",
          "methodName": "LeanCorpus_AddDocumentAsync_Sequential",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 36160871.9,
            "medianNanoseconds": 36075740.571428575,
            "minNanoseconds": 35948865.35714286,
            "maxNanoseconds": 36440724.21428572,
            "standardDeviationNanoseconds": 162996.27618193763,
            "operationsPerSecond": 27.654200450846986
          },
          "gc": {
            "bytesAllocatedPerOperation": 8118337,
            "gen0Collections": 13,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        },
        {
          "key": "AsyncIndexingBenchmarks.LeanCorpus_AddDocument_Sync|DocumentCount=1000",
          "displayInfo": "AsyncIndexingBenchmarks.LeanCorpus_AddDocument_Sync: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "AsyncIndexingBenchmarks",
          "methodName": "LeanCorpus_AddDocument_Sync",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 36248207.42857143,
            "medianNanoseconds": 36372425.28571428,
            "minNanoseconds": 35856001.928571425,
            "maxNanoseconds": 36516195.071428575,
            "standardDeviationNanoseconds": 347183.38597025676,
            "operationsPerSecond": 27.587571108738015
          },
          "gc": {
            "bytesAllocatedPerOperation": 8099450,
            "gen0Collections": 13,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        },
        {
          "key": "AsyncIndexingBenchmarks.LeanCorpus_AddDocumentsAsync_Batch|DocumentCount=1000",
          "displayInfo": "AsyncIndexingBenchmarks.LeanCorpus_AddDocumentsAsync_Batch: DefaultJob [DocumentCount=1000]",
          "typeName": "AsyncIndexingBenchmarks",
          "methodName": "LeanCorpus_AddDocumentsAsync_Batch",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 36099221.61538462,
            "medianNanoseconds": 36079700.21428572,
            "minNanoseconds": 35969164.21428572,
            "maxNanoseconds": 36320159.35714286,
            "standardDeviationNanoseconds": 92974.06488199107,
            "operationsPerSecond": 27.701428320377524
          },
          "gc": {
            "bytesAllocatedPerOperation": 8119353,
            "gen0Collections": 13,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "blockjoin-index",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.BlockJoinIndexBenchmarks-20260522-152840",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "BlockJoinIndexBenchmarks.LeanLucene_IndexBlocks|BlockCount=1000",
          "displayInfo": "BlockJoinIndexBenchmarks.LeanLucene_IndexBlocks: Job-CNUJVU(InvocationCount=1, UnrollFactor=1) [BlockCount=1000]",
          "typeName": "BlockJoinIndexBenchmarks",
          "methodName": "LeanLucene_IndexBlocks",
          "parameters": {
            "BlockCount": "1000"
          },
          "statistics": {
            "sampleCount": 25,
            "meanNanoseconds": 111717412,
            "medianNanoseconds": 110951530,
            "minNanoseconds": 108364645,
            "maxNanoseconds": 117205870,
            "standardDeviationNanoseconds": 2918480.82579803,
            "operationsPerSecond": 8.951156154601934
          },
          "gc": {
            "bytesAllocatedPerOperation": 20207784,
            "gen0Collections": 2,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "BlockJoinIndexBenchmarks.LuceneNet_IndexBlocks|BlockCount=1000",
          "displayInfo": "BlockJoinIndexBenchmarks.LuceneNet_IndexBlocks: Job-CNUJVU(InvocationCount=1, UnrollFactor=1) [BlockCount=1000]",
          "typeName": "BlockJoinIndexBenchmarks",
          "methodName": "LuceneNet_IndexBlocks",
          "parameters": {
            "BlockCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 102519459.85714285,
            "medianNanoseconds": 102311096,
            "minNanoseconds": 101545664,
            "maxNanoseconds": 104200990,
            "standardDeviationNanoseconds": 776104.2012306235,
            "operationsPerSecond": 9.754245695338852
          },
          "gc": {
            "bytesAllocatedPerOperation": 46205280,
            "gen0Collections": 8,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "blockjoin-search",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.BlockJoinSearchBenchmarks-20260522-153048",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "BlockJoinSearchBenchmarks.LeanLucene_BlockJoinQuery|BlockCount=1000",
          "displayInfo": "BlockJoinSearchBenchmarks.LeanLucene_BlockJoinQuery: DefaultJob [BlockCount=1000]",
          "typeName": "BlockJoinSearchBenchmarks",
          "methodName": "LeanLucene_BlockJoinQuery",
          "parameters": {
            "BlockCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10262.60262451172,
            "medianNanoseconds": 10258.213165283203,
            "minNanoseconds": 10236.02571105957,
            "maxNanoseconds": 10313.483001708984,
            "standardDeviationNanoseconds": 22.603632520565263,
            "operationsPerSecond": 97441.16932010496
          },
          "gc": {
            "bytesAllocatedPerOperation": 720,
            "gen0Collections": 11,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BlockJoinSearchBenchmarks.LuceneNet_ToParentBlockJoinQuery|BlockCount=1000",
          "displayInfo": "BlockJoinSearchBenchmarks.LuceneNet_ToParentBlockJoinQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BlockCount=1000]",
          "typeName": "BlockJoinSearchBenchmarks",
          "methodName": "LuceneNet_ToParentBlockJoinQuery",
          "parameters": {
            "BlockCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 32055.684448242188,
            "medianNanoseconds": 32000.746520996094,
            "minNanoseconds": 31948.911376953125,
            "maxNanoseconds": 32217.395446777344,
            "standardDeviationNanoseconds": 142.42385974588953,
            "operationsPerSecond": 31195.715119252
          },
          "gc": {
            "bytesAllocatedPerOperation": 11118,
            "gen0Collections": 43,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "boolean",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.BooleanQueryBenchmarks-20260522-144629",
      "benchmarkCount": 10,
      "benchmarks": [
        {
          "key": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery|BooleanShape=Must2Common, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BooleanShape=Must2Common, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery",
          "parameters": {
            "BooleanShape": "Must2Common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1362.0253035227458,
            "medianNanoseconds": 1361.0007934570312,
            "minNanoseconds": 1358.4835224151611,
            "maxNanoseconds": 1366.591594696045,
            "standardDeviationNanoseconds": 4.149990925781861,
            "operationsPerSecond": 734200.7504659402
          },
          "gc": {
            "bytesAllocatedPerOperation": 1360,
            "gen0Collections": 170,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery|BooleanShape=Must3Mixed, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BooleanShape=Must3Mixed, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery",
          "parameters": {
            "BooleanShape": "Must3Mixed",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1809.8027528127034,
            "medianNanoseconds": 1810.0768795013428,
            "minNanoseconds": 1806.9453678131104,
            "maxNanoseconds": 1812.3860111236572,
            "standardDeviationNanoseconds": 2.730660907036589,
            "operationsPerSecond": 552546.4023335421
          },
          "gc": {
            "bytesAllocatedPerOperation": 1592,
            "gen0Collections": 199,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery|BooleanShape=MustNotCommon, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery: DefaultJob [BooleanShape=MustNotCommon, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery",
          "parameters": {
            "BooleanShape": "MustNotCommon",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1197.3655227661134,
            "medianNanoseconds": 1196.5774097442627,
            "minNanoseconds": 1194.4417190551758,
            "maxNanoseconds": 1202.9746627807617,
            "standardDeviationNanoseconds": 2.6957071911771786,
            "operationsPerSecond": 835166.8567254499
          },
          "gc": {
            "bytesAllocatedPerOperation": 1352,
            "gen0Collections": 169,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery|BooleanShape=Should2Common, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery: DefaultJob [BooleanShape=Should2Common, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery",
          "parameters": {
            "BooleanShape": "Should2Common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 2230.3213550861065,
            "medianNanoseconds": 2228.5866050720215,
            "minNanoseconds": 2224.4744567871094,
            "maxNanoseconds": 2240.833209991455,
            "standardDeviationNanoseconds": 4.449150750130035,
            "operationsPerSecond": 448365.88132000057
          },
          "gc": {
            "bytesAllocatedPerOperation": 1536,
            "gen0Collections": 96,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery|BooleanShape=Should4Mixed, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LeanCorpus_BooleanQuery: DefaultJob [BooleanShape=Should4Mixed, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery",
          "parameters": {
            "BooleanShape": "Should4Mixed",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 3309.325600941976,
            "medianNanoseconds": 3309.286159515381,
            "minNanoseconds": 3294.959312438965,
            "maxNanoseconds": 3326.2724113464355,
            "standardDeviationNanoseconds": 10.188227328402386,
            "operationsPerSecond": 302176.37083379074
          },
          "gc": {
            "bytesAllocatedPerOperation": 2144,
            "gen0Collections": 134,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanShape=Must2Common, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: DefaultJob [BooleanShape=Must2Common, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanShape": "Must2Common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10507.763872273763,
            "medianNanoseconds": 10566.954544067383,
            "minNanoseconds": 10329.244888305664,
            "maxNanoseconds": 10638.081649780273,
            "standardDeviationNanoseconds": 116.3598982225797,
            "operationsPerSecond": 95167.72665958387
          },
          "gc": {
            "bytesAllocatedPerOperation": 13988,
            "gen0Collections": 217,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanShape=Must3Mixed, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: DefaultJob [BooleanShape=Must3Mixed, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanShape": "Must3Mixed",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 15471.12901204427,
            "medianNanoseconds": 15535.029205322266,
            "minNanoseconds": 14593.291381835938,
            "maxNanoseconds": 15616.765991210938,
            "standardDeviationNanoseconds": 250.61941363099248,
            "operationsPerSecond": 64636.52389049954
          },
          "gc": {
            "bytesAllocatedPerOperation": 20002,
            "gen0Collections": 155,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanShape=MustNotCommon, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BooleanShape=MustNotCommon, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanShape": "MustNotCommon",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 10682.897806803385,
            "medianNanoseconds": 10681.466171264648,
            "minNanoseconds": 10680.661178588867,
            "maxNanoseconds": 10686.56607055664,
            "standardDeviationNanoseconds": 3.202205884167952,
            "operationsPerSecond": 93607.56024111283
          },
          "gc": {
            "bytesAllocatedPerOperation": 13675,
            "gen0Collections": 212,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanShape=Should2Common, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BooleanShape=Should2Common, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanShape": "Should2Common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 51575.992696126305,
            "medianNanoseconds": 51519.412841796875,
            "minNanoseconds": 51515.194091796875,
            "maxNanoseconds": 51693.371154785156,
            "standardDeviationNanoseconds": 101.6746103053111,
            "operationsPerSecond": 19388.865782802597
          },
          "gc": {
            "bytesAllocatedPerOperation": 132436,
            "gen0Collections": 517,
            "gen1Collections": 6,
            "gen2Collections": 0
          }
        },
        {
          "key": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery|BooleanShape=Should4Mixed, DocumentCount=1000",
          "displayInfo": "BooleanQueryBenchmarks.LuceneNet_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [BooleanShape=Should4Mixed, DocumentCount=1000]",
          "typeName": "BooleanQueryBenchmarks",
          "methodName": "LuceneNet_BooleanQuery",
          "parameters": {
            "BooleanShape": "Should4Mixed",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 72514.7178548177,
            "medianNanoseconds": 72669.87048339844,
            "minNanoseconds": 72164.33203125,
            "maxNanoseconds": 72709.95104980469,
            "standardDeviationNanoseconds": 304.1040643739859,
            "operationsPerSecond": 13790.303949083936
          },
          "gc": {
            "bytesAllocatedPerOperation": 144787,
            "gen0Collections": 560,
            "gen1Collections": 7,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "collapse-facet",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.CollapseAndFacetBenchmarks-20260522-165250",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "CollapseAndFacetBenchmarks.LeanCorpus_BaseSearch|DocumentCount=1000",
          "displayInfo": "CollapseAndFacetBenchmarks.LeanCorpus_BaseSearch: DefaultJob [DocumentCount=1000]",
          "typeName": "CollapseAndFacetBenchmarks",
          "methodName": "LeanCorpus_BaseSearch",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 308.48881782804216,
            "medianNanoseconds": 308.1742100715637,
            "minNanoseconds": 307.77628803253174,
            "maxNanoseconds": 310.25667905807495,
            "standardDeviationNanoseconds": 0.6996164607504174,
            "operationsPerSecond": 3241608.584196462
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithCollapseAndFacets|DocumentCount=1000",
          "displayInfo": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithCollapseAndFacets: DefaultJob [DocumentCount=1000]",
          "typeName": "CollapseAndFacetBenchmarks",
          "methodName": "LeanCorpus_SearchWithCollapseAndFacets",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 307.3144480705261,
            "medianNanoseconds": 307.2784276008606,
            "minNanoseconds": 306.0434112548828,
            "maxNanoseconds": 309.49656677246094,
            "standardDeviationNanoseconds": 1.1049094144531315,
            "operationsPerSecond": 3253996.049578861
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithCollapse|DocumentCount=1000",
          "displayInfo": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithCollapse: DefaultJob [DocumentCount=1000]",
          "typeName": "CollapseAndFacetBenchmarks",
          "methodName": "LeanCorpus_SearchWithCollapse",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 307.6346673965454,
            "medianNanoseconds": 307.6208333969116,
            "minNanoseconds": 306.8515567779541,
            "maxNanoseconds": 308.61134099960327,
            "standardDeviationNanoseconds": 0.5416385237912151,
            "operationsPerSecond": 3250608.939697248
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithFacets|DocumentCount=1000",
          "displayInfo": "CollapseAndFacetBenchmarks.LeanCorpus_SearchWithFacets: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "CollapseAndFacetBenchmarks",
          "methodName": "LeanCorpus_SearchWithFacets",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 368.25551160176593,
            "medianNanoseconds": 367.83142614364624,
            "minNanoseconds": 367.43576431274414,
            "maxNanoseconds": 369.49934434890747,
            "standardDeviationNanoseconds": 1.0952063724496932,
            "operationsPerSecond": 2715505.860728045
          },
          "gc": {
            "bytesAllocatedPerOperation": 456,
            "gen0Collections": 228,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "combined",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.CombinedFieldsQueryBenchmarks-20260522-162441",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "CombinedFieldsQueryBenchmarks.LeanCorpus_BooleanQuery_MultiField|DocumentCount=1000, MinimumShouldMatch=1",
          "displayInfo": "CombinedFieldsQueryBenchmarks.LeanCorpus_BooleanQuery_MultiField: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MinimumShouldMatch=1, DocumentCount=1000]",
          "typeName": "CombinedFieldsQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery_MultiField",
          "parameters": {
            "MinimumShouldMatch": "1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2430.338063557943,
            "medianNanoseconds": 2430.372402191162,
            "minNanoseconds": 2426.7421646118164,
            "maxNanoseconds": 2433.8996238708496,
            "standardDeviationNanoseconds": 3.5788531846778184,
            "operationsPerSecond": 411465.3903482175
          },
          "gc": {
            "bytesAllocatedPerOperation": 2704,
            "gen0Collections": 169,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CombinedFieldsQueryBenchmarks.LeanCorpus_BooleanQuery_MultiField|DocumentCount=1000, MinimumShouldMatch=2",
          "displayInfo": "CombinedFieldsQueryBenchmarks.LeanCorpus_BooleanQuery_MultiField: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MinimumShouldMatch=2, DocumentCount=1000]",
          "typeName": "CombinedFieldsQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery_MultiField",
          "parameters": {
            "MinimumShouldMatch": "2",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2479.423141479492,
            "medianNanoseconds": 2479.4036254882812,
            "minNanoseconds": 2477.7974128723145,
            "maxNanoseconds": 2481.068386077881,
            "standardDeviationNanoseconds": 1.6355739308628185,
            "operationsPerSecond": 403319.6203062345
          },
          "gc": {
            "bytesAllocatedPerOperation": 2704,
            "gen0Collections": 169,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CombinedFieldsQueryBenchmarks.LeanCorpus_CombinedFieldsQuery|DocumentCount=1000, MinimumShouldMatch=1",
          "displayInfo": "CombinedFieldsQueryBenchmarks.LeanCorpus_CombinedFieldsQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MinimumShouldMatch=1, DocumentCount=1000]",
          "typeName": "CombinedFieldsQueryBenchmarks",
          "methodName": "LeanCorpus_CombinedFieldsQuery",
          "parameters": {
            "MinimumShouldMatch": "1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 3064.902535756429,
            "medianNanoseconds": 3066.7482948303223,
            "minNanoseconds": 3059.5127563476562,
            "maxNanoseconds": 3068.4465560913086,
            "standardDeviationNanoseconds": 4.744292822335597,
            "operationsPerSecond": 326274.6493024113
          },
          "gc": {
            "bytesAllocatedPerOperation": 3232,
            "gen0Collections": 202,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "CombinedFieldsQueryBenchmarks.LeanCorpus_CombinedFieldsQuery|DocumentCount=1000, MinimumShouldMatch=2",
          "displayInfo": "CombinedFieldsQueryBenchmarks.LeanCorpus_CombinedFieldsQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MinimumShouldMatch=2, DocumentCount=1000]",
          "typeName": "CombinedFieldsQueryBenchmarks",
          "methodName": "LeanCorpus_CombinedFieldsQuery",
          "parameters": {
            "MinimumShouldMatch": "2",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 3204.9063720703125,
            "medianNanoseconds": 3210.0731811523438,
            "minNanoseconds": 3186.0232849121094,
            "maxNanoseconds": 3218.6226501464844,
            "standardDeviationNanoseconds": 16.902709560560545,
            "operationsPerSecond": 312021.59561186115
          },
          "gc": {
            "bytesAllocatedPerOperation": 3232,
            "gen0Collections": 202,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "deletion-commit",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.DeletionCommitBenchmarks-20260522-151553",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "DeletionCommitBenchmarks.LeanLucene_CommitDeletes|DocumentCount=1000",
          "displayInfo": "DeletionCommitBenchmarks.LeanLucene_CommitDeletes: ShortRun(InvocationCount=1, IterationCount=3, LaunchCount=1, UnrollFactor=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "DeletionCommitBenchmarks",
          "methodName": "LeanLucene_CommitDeletes",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1220228,
            "medianNanoseconds": 1231472,
            "minNanoseconds": 1185500,
            "maxNanoseconds": 1243712,
            "standardDeviationNanoseconds": 30691.690862511958,
            "operationsPerSecond": 819.5189751423504
          },
          "gc": {
            "bytesAllocatedPerOperation": 278008,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DeletionCommitBenchmarks.LuceneNet_CommitDeletes|DocumentCount=1000",
          "displayInfo": "DeletionCommitBenchmarks.LuceneNet_CommitDeletes: Job-CNUJVU(InvocationCount=1, UnrollFactor=1) [DocumentCount=1000]",
          "typeName": "DeletionCommitBenchmarks",
          "methodName": "LuceneNet_CommitDeletes",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 99,
            "meanNanoseconds": 704715.6767676767,
            "medianNanoseconds": 703910,
            "minNanoseconds": 572836,
            "maxNanoseconds": 890003,
            "standardDeviationNanoseconds": 66288.56327864947,
            "operationsPerSecond": 1419.011997273433
          },
          "gc": {
            "bytesAllocatedPerOperation": 353920,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "deletion-queue",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.DeletionQueueBenchmarks-20260522-151439",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "DeletionQueueBenchmarks.LeanLucene_QueueDeletes|DocumentCount=1000",
          "displayInfo": "DeletionQueueBenchmarks.LeanLucene_QueueDeletes: Job-CNUJVU(InvocationCount=1, UnrollFactor=1) [DocumentCount=1000]",
          "typeName": "DeletionQueueBenchmarks",
          "methodName": "LeanLucene_QueueDeletes",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 87,
            "meanNanoseconds": 6826.9655172413795,
            "medianNanoseconds": 6531,
            "minNanoseconds": 5749,
            "maxNanoseconds": 9531,
            "standardDeviationNanoseconds": 912.3323987307792,
            "operationsPerSecond": 146477.96264306855
          },
          "gc": {
            "bytesAllocatedPerOperation": 10992,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DeletionQueueBenchmarks.LuceneNet_QueueDeletes|DocumentCount=1000",
          "displayInfo": "DeletionQueueBenchmarks.LuceneNet_QueueDeletes: Job-CNUJVU(InvocationCount=1, UnrollFactor=1) [DocumentCount=1000]",
          "typeName": "DeletionQueueBenchmarks",
          "methodName": "LuceneNet_QueueDeletes",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 91,
            "meanNanoseconds": 38434.45054945055,
            "medianNanoseconds": 36901,
            "minNanoseconds": 34535,
            "maxNanoseconds": 51287,
            "standardDeviationNanoseconds": 4002.2143988984026,
            "operationsPerSecond": 26018.324334138186
          },
          "gc": {
            "bytesAllocatedPerOperation": 26112,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "dismax",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.DisjunctionMaxQueryBenchmarks-20260522-155906",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [TieBreakerMultiplier=0, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LeanCorpus_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2747.315153757731,
            "medianNanoseconds": 2745.8230018615723,
            "minNanoseconds": 2742.3345222473145,
            "maxNanoseconds": 2753.7879371643066,
            "standardDeviationNanoseconds": 5.87069555300755,
            "operationsPerSecond": 363991.73157554097
          },
          "gc": {
            "bytesAllocatedPerOperation": 1488,
            "gen0Collections": 93,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0.1",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [TieBreakerMultiplier=0.1, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LeanCorpus_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0.1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2733.483081817627,
            "medianNanoseconds": 2730.275043487549,
            "minNanoseconds": 2729.486656188965,
            "maxNanoseconds": 2740.687545776367,
            "standardDeviationNanoseconds": 6.251688918422956,
            "operationsPerSecond": 365833.61596481915
          },
          "gc": {
            "bytesAllocatedPerOperation": 1488,
            "gen0Collections": 93,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0.5",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LeanCorpus_DisjunctionMaxQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [TieBreakerMultiplier=0.5, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LeanCorpus_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0.5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2776.2626953125,
            "medianNanoseconds": 2778.7029457092285,
            "minNanoseconds": 2770.2977447509766,
            "maxNanoseconds": 2779.787395477295,
            "standardDeviationNanoseconds": 5.1941779162759625,
            "operationsPerSecond": 360196.461843622
          },
          "gc": {
            "bytesAllocatedPerOperation": 1488,
            "gen0Collections": 93,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery: DefaultJob [TieBreakerMultiplier=0, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LuceneNet_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 14049.347452799479,
            "medianNanoseconds": 14042.577362060547,
            "minNanoseconds": 14007.81118774414,
            "maxNanoseconds": 14099.072784423828,
            "standardDeviationNanoseconds": 28.773939261251268,
            "operationsPerSecond": 71177.68304610757
          },
          "gc": {
            "bytesAllocatedPerOperation": 28232,
            "gen0Collections": 442,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0.1",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [TieBreakerMultiplier=0.1, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LuceneNet_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0.1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 13985.723047892252,
            "medianNanoseconds": 13973.934844970703,
            "minNanoseconds": 13950.089797973633,
            "maxNanoseconds": 14033.144500732422,
            "standardDeviationNanoseconds": 42.76379553638126,
            "operationsPerSecond": 71501.4873793534
          },
          "gc": {
            "bytesAllocatedPerOperation": 28232,
            "gen0Collections": 442,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery|DocumentCount=1000, TieBreakerMultiplier=0.5",
          "displayInfo": "DisjunctionMaxQueryBenchmarks.LuceneNet_DisjunctionMaxQuery: DefaultJob [TieBreakerMultiplier=0.5, DocumentCount=1000]",
          "typeName": "DisjunctionMaxQueryBenchmarks",
          "methodName": "LuceneNet_DisjunctionMaxQuery",
          "parameters": {
            "TieBreakerMultiplier": "0.5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 14286.061303710938,
            "medianNanoseconds": 14288.856964111328,
            "minNanoseconds": 14250.679916381836,
            "maxNanoseconds": 14307.831558227539,
            "standardDeviationNanoseconds": 18.323395667829363,
            "operationsPerSecond": 69998.29965311998
          },
          "gc": {
            "bytesAllocatedPerOperation": 28232,
            "gen0Collections": 442,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "function-score",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.FunctionScoreQueryBenchmarks-20260522-164422",
      "benchmarkCount": 8,
      "benchmarks": [
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery|DocumentCount=1000, Mode=Max",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery: DefaultJob [Mode=Max, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_BaseTermQuery",
          "parameters": {
            "Mode": "Max",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 304.0806464195251,
            "medianNanoseconds": 304.1677556037903,
            "minNanoseconds": 303.359477519989,
            "maxNanoseconds": 305.0131163597107,
            "standardDeviationNanoseconds": 0.5643141930048884,
            "operationsPerSecond": 3288601.2700076583
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery|DocumentCount=1000, Mode=Multiply",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Mode=Multiply, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_BaseTermQuery",
          "parameters": {
            "Mode": "Multiply",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 308.4732626279195,
            "medianNanoseconds": 308.28629875183105,
            "minNanoseconds": 307.83144664764404,
            "maxNanoseconds": 309.30204248428345,
            "standardDeviationNanoseconds": 0.7529141032726131,
            "operationsPerSecond": 3241772.046889523
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery|DocumentCount=1000, Mode=Replace",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Mode=Replace, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_BaseTermQuery",
          "parameters": {
            "Mode": "Replace",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 303.0517137845357,
            "medianNanoseconds": 303.4405002593994,
            "minNanoseconds": 302.22786951065063,
            "maxNanoseconds": 303.48677158355713,
            "standardDeviationNanoseconds": 0.7138450809312668,
            "operationsPerSecond": 3299766.853359496
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery|DocumentCount=1000, Mode=Sum",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_BaseTermQuery: DefaultJob [Mode=Sum, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_BaseTermQuery",
          "parameters": {
            "Mode": "Sum",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 303.4445843696594,
            "medianNanoseconds": 303.4458165168762,
            "minNanoseconds": 302.7816457748413,
            "maxNanoseconds": 304.45749282836914,
            "standardDeviationNanoseconds": 0.5176285088635224,
            "operationsPerSecond": 3295494.6356260865
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery|DocumentCount=1000, Mode=Max",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery: DefaultJob [Mode=Max, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_FunctionScoreQuery",
          "parameters": {
            "Mode": "Max",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 967.2843344761775,
            "medianNanoseconds": 966.9742774963379,
            "minNanoseconds": 965.6326179504395,
            "maxNanoseconds": 969.1214351654053,
            "standardDeviationNanoseconds": 1.120517685035373,
            "operationsPerSecond": 1033822.1806740407
          },
          "gc": {
            "bytesAllocatedPerOperation": 8624,
            "gen0Collections": 1082,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery|DocumentCount=1000, Mode=Multiply",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Mode=Multiply, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_FunctionScoreQuery",
          "parameters": {
            "Mode": "Multiply",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 960.3420848846436,
            "medianNanoseconds": 959.5848236083984,
            "minNanoseconds": 956.9002857208252,
            "maxNanoseconds": 964.541145324707,
            "standardDeviationNanoseconds": 3.8763084696568733,
            "operationsPerSecond": 1041295.6130316003
          },
          "gc": {
            "bytesAllocatedPerOperation": 8624,
            "gen0Collections": 1082,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery|DocumentCount=1000, Mode=Replace",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Mode=Replace, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_FunctionScoreQuery",
          "parameters": {
            "Mode": "Replace",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 961.882069269816,
            "medianNanoseconds": 962.2322654724121,
            "minNanoseconds": 959.1844940185547,
            "maxNanoseconds": 964.2294483184814,
            "standardDeviationNanoseconds": 2.540643423883383,
            "operationsPerSecond": 1039628.4866388247
          },
          "gc": {
            "bytesAllocatedPerOperation": 8624,
            "gen0Collections": 1082,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery|DocumentCount=1000, Mode=Sum",
          "displayInfo": "FunctionScoreQueryBenchmarks.LeanCorpus_FunctionScoreQuery: DefaultJob [Mode=Sum, DocumentCount=1000]",
          "typeName": "FunctionScoreQueryBenchmarks",
          "methodName": "LeanCorpus_FunctionScoreQuery",
          "parameters": {
            "Mode": "Sum",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 965.3608710425241,
            "medianNanoseconds": 965.1886310577393,
            "minNanoseconds": 963.200704574585,
            "maxNanoseconds": 968.4924201965332,
            "standardDeviationNanoseconds": 1.6148928742160575,
            "operationsPerSecond": 1035882.0519833873
          },
          "gc": {
            "bytesAllocatedPerOperation": 8624,
            "gen0Collections": 1082,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "fuzzy",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.FuzzyQueryBenchmarks-20260522-150251",
      "benchmarkCount": 10,
      "benchmarks": [
        {
          "key": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery|DocumentCount=1000, Scenario=long-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=long-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanCorpus_FuzzyQuery",
          "parameters": {
            "Scenario": "long-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 206.18218596776327,
            "medianNanoseconds": 206.00940346717834,
            "minNanoseconds": 205.79765343666077,
            "maxNanoseconds": 206.73950099945068,
            "standardDeviationNanoseconds": 0.49412503707524286,
            "operationsPerSecond": 4850079.531877456
          },
          "gc": {
            "bytesAllocatedPerOperation": 448,
            "gen0Collections": 449,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery|DocumentCount=1000, Scenario=medium-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=medium-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanCorpus_FuzzyQuery",
          "parameters": {
            "Scenario": "medium-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 208.05884130795798,
            "medianNanoseconds": 207.75738739967346,
            "minNanoseconds": 207.7246105670929,
            "maxNanoseconds": 208.69452595710754,
            "standardDeviationNanoseconds": 0.550762934538826,
            "operationsPerSecond": 4806332.639908589
          },
          "gc": {
            "bytesAllocatedPerOperation": 448,
            "gen0Collections": 449,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery|DocumentCount=1000, Scenario=medium-edit2-common",
          "displayInfo": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery: DefaultJob [Scenario=medium-edit2-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanCorpus_FuzzyQuery",
          "parameters": {
            "Scenario": "medium-edit2-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1037.0992950711932,
            "medianNanoseconds": 1036.5270223617554,
            "minNanoseconds": 1034.9040622711182,
            "maxNanoseconds": 1040.830738067627,
            "standardDeviationNanoseconds": 1.6586739492210758,
            "operationsPerSecond": 964227.8273184571
          },
          "gc": {
            "bytesAllocatedPerOperation": 544,
            "gen0Collections": 68,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery|DocumentCount=1000, Scenario=nohit-edit2",
          "displayInfo": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery: DefaultJob [Scenario=nohit-edit2, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanCorpus_FuzzyQuery",
          "parameters": {
            "Scenario": "nohit-edit2",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 209.17508343287878,
            "medianNanoseconds": 209.0909388065338,
            "minNanoseconds": 208.73815369606018,
            "maxNanoseconds": 209.96701765060425,
            "standardDeviationNanoseconds": 0.3152243787500773,
            "operationsPerSecond": 4780684.121590827
          },
          "gc": {
            "bytesAllocatedPerOperation": 456,
            "gen0Collections": 457,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery|DocumentCount=1000, Scenario=short-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LeanCorpus_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=short-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LeanCorpus_FuzzyQuery",
          "parameters": {
            "Scenario": "short-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2462.876984914144,
            "medianNanoseconds": 2462.8892669677734,
            "minNanoseconds": 2455.481014251709,
            "maxNanoseconds": 2470.260673522949,
            "standardDeviationNanoseconds": 7.389837290503789,
            "operationsPerSecond": 406029.21141628193
          },
          "gc": {
            "bytesAllocatedPerOperation": 664,
            "gen0Collections": 41,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=1000, Scenario=long-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: DefaultJob [Scenario=long-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "Scenario": "long-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 211766.59720052083,
            "medianNanoseconds": 211731.24145507812,
            "minNanoseconds": 211265.7939453125,
            "maxNanoseconds": 212366.97924804688,
            "standardDeviationNanoseconds": 311.960842047692,
            "operationsPerSecond": 4722.180047371232
          },
          "gc": {
            "bytesAllocatedPerOperation": 330291,
            "gen0Collections": 323,
            "gen1Collections": 11,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=1000, Scenario=medium-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: DefaultJob [Scenario=medium-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "Scenario": "medium-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 268796.45950520836,
            "medianNanoseconds": 268652.82861328125,
            "minNanoseconds": 268052.3037109375,
            "maxNanoseconds": 270067.91064453125,
            "standardDeviationNanoseconds": 669.1434091159263,
            "operationsPerSecond": 3720.2870969385795
          },
          "gc": {
            "bytesAllocatedPerOperation": 383808,
            "gen0Collections": 187,
            "gen1Collections": 4,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=1000, Scenario=medium-edit2-common",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=medium-edit2-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "Scenario": "medium-edit2-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1193378.1497395833,
            "medianNanoseconds": 1195012.537109375,
            "minNanoseconds": 1189432.634765625,
            "maxNanoseconds": 1195689.27734375,
            "standardDeviationNanoseconds": 3433.629368977169,
            "operationsPerSecond": 837.9573567843672
          },
          "gc": {
            "bytesAllocatedPerOperation": 1371218,
            "gen0Collections": 154,
            "gen1Collections": 40,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=1000, Scenario=nohit-edit2",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=nohit-edit2, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "Scenario": "nohit-edit2",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1624411.9680989583,
            "medianNanoseconds": 1623789.947265625,
            "minNanoseconds": 1618880.19921875,
            "maxNanoseconds": 1630565.7578125,
            "standardDeviationNanoseconds": 5867.559317963189,
            "operationsPerSecond": 615.6073826335418
          },
          "gc": {
            "bytesAllocatedPerOperation": 1827054,
            "gen0Collections": 191,
            "gen1Collections": 69,
            "gen2Collections": 0
          }
        },
        {
          "key": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery|DocumentCount=1000, Scenario=short-edit1-common",
          "displayInfo": "FuzzyQueryBenchmarks.LuceneNet_FuzzyQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Scenario=short-edit1-common, DocumentCount=1000]",
          "typeName": "FuzzyQueryBenchmarks",
          "methodName": "LuceneNet_FuzzyQuery",
          "parameters": {
            "Scenario": "short-edit1-common",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 211459.72102864584,
            "medianNanoseconds": 211628.798828125,
            "minNanoseconds": 208961.95849609375,
            "maxNanoseconds": 213788.40576171875,
            "standardDeviationNanoseconds": 2417.6618412574367,
            "operationsPerSecond": 4729.033005129771
          },
          "gc": {
            "bytesAllocatedPerOperation": 298744,
            "gen0Collections": 292,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "geo",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.GeoQueryBenchmarks-20260522-164921",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "GeoQueryBenchmarks.LeanCorpus_GeoBoundingBoxQuery|DocumentCount=1000, GeoQueryType=BoundingBox",
          "displayInfo": "GeoQueryBenchmarks.LeanCorpus_GeoBoundingBoxQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GeoQueryType=BoundingBox, DocumentCount=1000]",
          "typeName": "GeoQueryBenchmarks",
          "methodName": "LeanCorpus_GeoBoundingBoxQuery",
          "parameters": {
            "GeoQueryType": "BoundingBox",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 3331.07545598348,
            "medianNanoseconds": 3331.1278648376465,
            "minNanoseconds": 3326.698287963867,
            "maxNanoseconds": 3335.400215148926,
            "standardDeviationNanoseconds": 4.351200317097771,
            "operationsPerSecond": 300203.34670105996
          },
          "gc": {
            "bytesAllocatedPerOperation": 3200,
            "gen0Collections": 200,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GeoQueryBenchmarks.LeanCorpus_GeoBoundingBoxQuery|DocumentCount=1000, GeoQueryType=Distance",
          "displayInfo": "GeoQueryBenchmarks.LeanCorpus_GeoBoundingBoxQuery: DefaultJob [GeoQueryType=Distance, DocumentCount=1000]",
          "typeName": "GeoQueryBenchmarks",
          "methodName": "LeanCorpus_GeoBoundingBoxQuery",
          "parameters": {
            "GeoQueryType": "Distance",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 3341.2655517578123,
            "medianNanoseconds": 3339.6693420410156,
            "minNanoseconds": 3334.309883117676,
            "maxNanoseconds": 3352.8214950561523,
            "standardDeviationNanoseconds": 5.334022761896468,
            "operationsPerSecond": 299287.7951511242
          },
          "gc": {
            "bytesAllocatedPerOperation": 3200,
            "gen0Collections": 200,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GeoQueryBenchmarks.LeanCorpus_GeoDistanceQuery|DocumentCount=1000, GeoQueryType=BoundingBox",
          "displayInfo": "GeoQueryBenchmarks.LeanCorpus_GeoDistanceQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GeoQueryType=BoundingBox, DocumentCount=1000]",
          "typeName": "GeoQueryBenchmarks",
          "methodName": "LeanCorpus_GeoDistanceQuery",
          "parameters": {
            "GeoQueryType": "BoundingBox",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2471.885270436605,
            "medianNanoseconds": 2470.5845680236816,
            "minNanoseconds": 2468.9983825683594,
            "maxNanoseconds": 2476.0728607177734,
            "standardDeviationNanoseconds": 3.7122675478570217,
            "operationsPerSecond": 404549.5201415119
          },
          "gc": {
            "bytesAllocatedPerOperation": 1168,
            "gen0Collections": 73,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GeoQueryBenchmarks.LeanCorpus_GeoDistanceQuery|DocumentCount=1000, GeoQueryType=Distance",
          "displayInfo": "GeoQueryBenchmarks.LeanCorpus_GeoDistanceQuery: DefaultJob [GeoQueryType=Distance, DocumentCount=1000]",
          "typeName": "GeoQueryBenchmarks",
          "methodName": "LeanCorpus_GeoDistanceQuery",
          "parameters": {
            "GeoQueryType": "Distance",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 2468.4576502482096,
            "medianNanoseconds": 2466.5537452697754,
            "minNanoseconds": 2462.706214904785,
            "maxNanoseconds": 2481.532154083252,
            "standardDeviationNanoseconds": 5.934753850556786,
            "operationsPerSecond": 405111.26447700954
          },
          "gc": {
            "bytesAllocatedPerOperation": 1168,
            "gen0Collections": 73,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-analysis",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.GutenbergAnalysisBenchmarks-20260522-153258",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "GutenbergAnalysisBenchmarks.LeanCorpus_English_Analyse",
          "displayInfo": "GutenbergAnalysisBenchmarks.LeanCorpus_English_Analyse: DefaultJob",
          "typeName": "GutenbergAnalysisBenchmarks",
          "methodName": "LeanCorpus_English_Analyse",
          "parameters": {},
          "statistics": {
            "sampleCount": 100,
            "meanNanoseconds": 447962029.03,
            "medianNanoseconds": 429297746.5,
            "minNanoseconds": 411843668,
            "maxNanoseconds": 512500228,
            "standardDeviationNanoseconds": 35642231.72285931,
            "operationsPerSecond": 2.232332062084285
          },
          "gc": {
            "bytesAllocatedPerOperation": 208675448,
            "gen0Collections": 13,
            "gen1Collections": 8,
            "gen2Collections": 3
          }
        },
        {
          "key": "GutenbergAnalysisBenchmarks.LeanCorpus_Standard_Analyse",
          "displayInfo": "GutenbergAnalysisBenchmarks.LeanCorpus_Standard_Analyse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)",
          "typeName": "GutenbergAnalysisBenchmarks",
          "methodName": "LeanCorpus_Standard_Analyse",
          "parameters": {},
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 126366106.75,
            "medianNanoseconds": 126352696.5,
            "minNanoseconds": 125918967,
            "maxNanoseconds": 126826656.75,
            "standardDeviationNanoseconds": 453993.44341913407,
            "operationsPerSecond": 7.913514356965817
          },
          "gc": {
            "bytesAllocatedPerOperation": 7619280,
            "gen0Collections": 5,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-index",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.GutenbergIndexingBenchmarks-20260522-153559",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "GutenbergIndexingBenchmarks.LeanCorpus_English_Index",
          "displayInfo": "GutenbergIndexingBenchmarks.LeanCorpus_English_Index: DefaultJob",
          "typeName": "GutenbergIndexingBenchmarks",
          "methodName": "LeanCorpus_English_Index",
          "parameters": {},
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 962457673.8571428,
            "medianNanoseconds": 962089689.5,
            "minNanoseconds": 956188631,
            "maxNanoseconds": 970582097,
            "standardDeviationNanoseconds": 4180131.922448912,
            "operationsPerSecond": 1.0390067295036494
          },
          "gc": {
            "bytesAllocatedPerOperation": 311966240,
            "gen0Collections": 47,
            "gen1Collections": 14,
            "gen2Collections": 1
          }
        },
        {
          "key": "GutenbergIndexingBenchmarks.LeanCorpus_Standard_Index",
          "displayInfo": "GutenbergIndexingBenchmarks.LeanCorpus_Standard_Index: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)",
          "typeName": "GutenbergIndexingBenchmarks",
          "methodName": "LeanCorpus_Standard_Index",
          "parameters": {},
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 746243420.6666666,
            "medianNanoseconds": 746335537,
            "minNanoseconds": 741040597,
            "maxNanoseconds": 751354128,
            "standardDeviationNanoseconds": 5157382.5227667885,
            "operationsPerSecond": 1.3400453153833323
          },
          "gc": {
            "bytesAllocatedPerOperation": 117380912,
            "gen0Collections": 16,
            "gen1Collections": 8,
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
            "sampleCount": 12,
            "meanNanoseconds": 630889587.8333334,
            "medianNanoseconds": 631184098.5,
            "minNanoseconds": 626870268,
            "maxNanoseconds": 634592165,
            "standardDeviationNanoseconds": 2358496.6006570924,
            "operationsPerSecond": 1.585063407741922
          },
          "gc": {
            "bytesAllocatedPerOperation": 218236224,
            "gen0Collections": 42,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "gutenberg-search",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.GutenbergSearchBenchmarks-20260522-153938",
      "benchmarkCount": 15,
      "benchmarks": [
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_English_Search|SearchTerm=death",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_English_Search: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SearchTerm=death]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_English_Search",
          "parameters": {
            "SearchTerm": "death"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 12681.977930704752,
            "medianNanoseconds": 12680.32292175293,
            "minNanoseconds": 12677.767349243164,
            "maxNanoseconds": 12687.843521118164,
            "standardDeviationNanoseconds": 5.2379958845531505,
            "operationsPerSecond": 78852.0533203947
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_English_Search|SearchTerm=love",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_English_Search: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SearchTerm=love]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_English_Search",
          "parameters": {
            "SearchTerm": "love"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 22258.133677164715,
            "medianNanoseconds": 22267.402893066406,
            "minNanoseconds": 22237.844024658203,
            "maxNanoseconds": 22269.15411376953,
            "standardDeviationNanoseconds": 17.593157550990437,
            "operationsPerSecond": 44927.39663190764
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_English_Search|SearchTerm=man",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_English_Search: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SearchTerm=man]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_English_Search",
          "parameters": {
            "SearchTerm": "man"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 44534.753967285156,
            "medianNanoseconds": 44557.511657714844,
            "minNanoseconds": 44461.9072265625,
            "maxNanoseconds": 44584.843017578125,
            "standardDeviationNanoseconds": 64.55026362013926,
            "operationsPerSecond": 22454.373515447987
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_English_Search|SearchTerm=night",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_English_Search: DefaultJob [SearchTerm=night]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_English_Search",
          "parameters": {
            "SearchTerm": "night"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 29815.09200439453,
            "medianNanoseconds": 29814.01055908203,
            "minNanoseconds": 29721.978302001953,
            "maxNanoseconds": 29946.517333984375,
            "standardDeviationNanoseconds": 68.82222553234186,
            "operationsPerSecond": 33540.060847459645
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_English_Search|SearchTerm=sea",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_English_Search: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SearchTerm=sea]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_English_Search",
          "parameters": {
            "SearchTerm": "sea"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 15550.09595743815,
            "medianNanoseconds": 15547.206970214844,
            "minNanoseconds": 15529.446014404297,
            "maxNanoseconds": 15573.634887695312,
            "standardDeviationNanoseconds": 22.235642919976097,
            "operationsPerSecond": 64308.284832265956
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search|SearchTerm=death",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search: DefaultJob [SearchTerm=death]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_Standard_Search",
          "parameters": {
            "SearchTerm": "death"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 12853.30518391927,
            "medianNanoseconds": 12868.175537109375,
            "minNanoseconds": 12752.358139038086,
            "maxNanoseconds": 12935.411270141602,
            "standardDeviationNanoseconds": 53.084243512373604,
            "operationsPerSecond": 77801.00026342616
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search|SearchTerm=love",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search: DefaultJob [SearchTerm=love]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_Standard_Search",
          "parameters": {
            "SearchTerm": "love"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 16829.497666422525,
            "medianNanoseconds": 16826.532653808594,
            "minNanoseconds": 16796.610748291016,
            "maxNanoseconds": 16865.198364257812,
            "standardDeviationNanoseconds": 20.831249170622552,
            "operationsPerSecond": 59419.47999999763
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search|SearchTerm=man",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search: DefaultJob [SearchTerm=man]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_Standard_Search",
          "parameters": {
            "SearchTerm": "man"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 44523.59569440569,
            "medianNanoseconds": 44504.936126708984,
            "minNanoseconds": 44446.743896484375,
            "maxNanoseconds": 44602.00262451172,
            "standardDeviationNanoseconds": 43.57295523076358,
            "operationsPerSecond": 22460.000914203978
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search|SearchTerm=night",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SearchTerm=night]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_Standard_Search",
          "parameters": {
            "SearchTerm": "night"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 28369.157145182293,
            "medianNanoseconds": 28370.822814941406,
            "minNanoseconds": 28347.084259033203,
            "maxNanoseconds": 28389.564361572266,
            "standardDeviationNanoseconds": 21.2889788327702,
            "operationsPerSecond": 35249.54918055512
          },
          "gc": {
            "bytesAllocatedPerOperation": 472,
            "gen0Collections": 3,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search|SearchTerm=sea",
          "displayInfo": "GutenbergSearchBenchmarks.LeanCorpus_Standard_Search: DefaultJob [SearchTerm=sea]",
          "typeName": "GutenbergSearchBenchmarks",
          "methodName": "LeanCorpus_Standard_Search",
          "parameters": {
            "SearchTerm": "sea"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 14043.798850504558,
            "medianNanoseconds": 14028.144729614258,
            "minNanoseconds": 14005.148223876953,
            "maxNanoseconds": 14104.93881225586,
            "standardDeviationNanoseconds": 32.33489822412372,
            "operationsPerSecond": 71205.8048285185
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
            "meanNanoseconds": 22174.998606363934,
            "medianNanoseconds": 22413.78012084961,
            "minNanoseconds": 21496.578979492188,
            "maxNanoseconds": 22506.676544189453,
            "standardDeviationNanoseconds": 407.5499376961774,
            "operationsPerSecond": 45095.831469996716
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
            "sampleCount": 15,
            "meanNanoseconds": 29013.478377278647,
            "medianNanoseconds": 29005.720947265625,
            "minNanoseconds": 28947.958038330078,
            "maxNanoseconds": 29105.721160888672,
            "standardDeviationNanoseconds": 50.86235310590669,
            "operationsPerSecond": 34466.739458000695
          },
          "gc": {
            "bytesAllocatedPerOperation": 11175,
            "gen0Collections": 86,
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
            "meanNanoseconds": 50447.79186197917,
            "medianNanoseconds": 50413.471923828125,
            "minNanoseconds": 50335.674255371094,
            "maxNanoseconds": 50624.93591308594,
            "standardDeviationNanoseconds": 92.72887315644398,
            "operationsPerSecond": 19822.473156722386
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
            "meanNanoseconds": 35899.906502278645,
            "medianNanoseconds": 35872.70330810547,
            "minNanoseconds": 35825.62615966797,
            "maxNanoseconds": 36069.55358886719,
            "standardDeviationNanoseconds": 66.76048721705511,
            "operationsPerSecond": 27855.225749307392
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
            "sampleCount": 13,
            "meanNanoseconds": 26062.99486365685,
            "medianNanoseconds": 26066.352111816406,
            "minNanoseconds": 26008.262573242188,
            "maxNanoseconds": 26134.110595703125,
            "standardDeviationNanoseconds": 34.83556151698784,
            "operationsPerSecond": 38368.57603016432
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
      "suiteName": "highlighter",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.HighlighterBenchmarks-20260522-161718",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms|DocumentCount=1000, MaxSnippetLength=100",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxSnippetLength=100, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_FiveTerms",
          "parameters": {
            "MaxSnippetLength": "100",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 5670617.528645833,
            "medianNanoseconds": 5659010.546875,
            "minNanoseconds": 5658405.3203125,
            "maxNanoseconds": 5694436.71875,
            "standardDeviationNanoseconds": 20630.24327805691,
            "operationsPerSecond": 176.3476367341608
          },
          "gc": {
            "bytesAllocatedPerOperation": 648256,
            "gen0Collections": 19,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms|DocumentCount=1000, MaxSnippetLength=200",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxSnippetLength=200, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_FiveTerms",
          "parameters": {
            "MaxSnippetLength": "200",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 5760496.403645833,
            "medianNanoseconds": 5757847.6640625,
            "minNanoseconds": 5757171.1171875,
            "maxNanoseconds": 5766470.4296875,
            "standardDeviationNanoseconds": 5184.705322234012,
            "operationsPerSecond": 173.5961503885494
          },
          "gc": {
            "bytesAllocatedPerOperation": 849080,
            "gen0Collections": 25,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms|DocumentCount=1000, MaxSnippetLength=500",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_FiveTerms: DefaultJob [MaxSnippetLength=500, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_FiveTerms",
          "parameters": {
            "MaxSnippetLength": "500",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 6028751.082291666,
            "medianNanoseconds": 6027239.5,
            "minNanoseconds": 6012822.6171875,
            "maxNanoseconds": 6044942.9375,
            "standardDeviationNanoseconds": 10801.986552696068,
            "operationsPerSecond": 165.8718342074719
          },
          "gc": {
            "bytesAllocatedPerOperation": 1088472,
            "gen0Collections": 33,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms|DocumentCount=1000, MaxSnippetLength=100",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxSnippetLength=100, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_TwoTerms",
          "parameters": {
            "MaxSnippetLength": "100",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 5410264.455729167,
            "medianNanoseconds": 5406895.9921875,
            "minNanoseconds": 5404904.7265625,
            "maxNanoseconds": 5418992.6484375,
            "standardDeviationNanoseconds": 7624.12589499144,
            "operationsPerSecond": 184.83384836041722
          },
          "gc": {
            "bytesAllocatedPerOperation": 591536,
            "gen0Collections": 18,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms|DocumentCount=1000, MaxSnippetLength=200",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxSnippetLength=200, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_TwoTerms",
          "parameters": {
            "MaxSnippetLength": "200",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 5568805.260416667,
            "medianNanoseconds": 5574663.1171875,
            "minNanoseconds": 5551260.6875,
            "maxNanoseconds": 5580491.9765625,
            "standardDeviationNanoseconds": 15471.03517947511,
            "operationsPerSecond": 179.57173096140525
          },
          "gc": {
            "bytesAllocatedPerOperation": 800072,
            "gen0Collections": 24,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms|DocumentCount=1000, MaxSnippetLength=500",
          "displayInfo": "HighlighterBenchmarks.LeanCorpus_Highlight_TwoTerms: DefaultJob [MaxSnippetLength=500, DocumentCount=1000]",
          "typeName": "HighlighterBenchmarks",
          "methodName": "LeanCorpus_Highlight_TwoTerms",
          "parameters": {
            "MaxSnippetLength": "500",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 5723365.84375,
            "medianNanoseconds": 5721047.5,
            "minNanoseconds": 5702806.4375,
            "maxNanoseconds": 5757613.203125,
            "standardDeviationNanoseconds": 14176.788984118546,
            "operationsPerSecond": 174.72236220789813
          },
          "gc": {
            "bytesAllocatedPerOperation": 1052720,
            "gen0Collections": 32,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "hunspell",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.HunspellBenchmarks-20260522-170550",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "HunspellBenchmarks.Parse_Dictionary",
          "displayInfo": "HunspellBenchmarks.Parse_Dictionary: DefaultJob",
          "typeName": "HunspellBenchmarks",
          "methodName": "Parse_Dictionary",
          "parameters": {},
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 294.7136449813843,
            "medianNanoseconds": 294.56120777130127,
            "minNanoseconds": 293.96487379074097,
            "maxNanoseconds": 295.9850220680237,
            "standardDeviationNanoseconds": 0.5435050791756326,
            "operationsPerSecond": 3393124.1970936414
          },
          "gc": {
            "bytesAllocatedPerOperation": 176,
            "gen0Collections": 88,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "HunspellBenchmarks.Stem_Words",
          "displayInfo": "HunspellBenchmarks.Stem_Words: DefaultJob",
          "typeName": "HunspellBenchmarks",
          "methodName": "Stem_Words",
          "parameters": {},
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 100.67231484821865,
            "medianNanoseconds": 100.66332566738129,
            "minNanoseconds": 100.55832433700562,
            "maxNanoseconds": 100.83720183372498,
            "standardDeviationNanoseconds": 0.07765737360808299,
            "operationsPerSecond": 9933217.503815992
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "index",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.IndexingBenchmarks-20260522-143133",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexingBenchmarks.LeanCorpus_IndexDocuments|DocumentCount=1000",
          "displayInfo": "IndexingBenchmarks.LeanCorpus_IndexDocuments: DefaultJob [DocumentCount=1000]",
          "typeName": "IndexingBenchmarks",
          "methodName": "LeanCorpus_IndexDocuments",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 64,
            "meanNanoseconds": 36982469.602678575,
            "medianNanoseconds": 37033842.85714286,
            "minNanoseconds": 34831612.35714286,
            "maxNanoseconds": 39010667.928571425,
            "standardDeviationNanoseconds": 1705218.1354557083,
            "operationsPerSecond": 27.039838354320494
          },
          "gc": {
            "bytesAllocatedPerOperation": 8313243,
            "gen0Collections": 13,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        },
        {
          "key": "IndexingBenchmarks.LuceneNet_IndexDocuments|DocumentCount=1000",
          "displayInfo": "IndexingBenchmarks.LuceneNet_IndexDocuments: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "IndexingBenchmarks",
          "methodName": "LuceneNet_IndexDocuments",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 28585690.072916668,
            "medianNanoseconds": 28601174.625,
            "minNanoseconds": 28485434.875,
            "maxNanoseconds": 28670460.71875,
            "standardDeviationNanoseconds": 93479.77978560899,
            "operationsPerSecond": 34.98253837669092
          },
          "gc": {
            "bytesAllocatedPerOperation": 16264999,
            "gen0Collections": 95,
            "gen1Collections": 20,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "indexsort-index",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.IndexSortIndexBenchmarks-20260522-152402",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexSortIndexBenchmarks.LeanCorpus_Index_Sorted|DocumentCount=1000",
          "displayInfo": "IndexSortIndexBenchmarks.LeanCorpus_Index_Sorted: DefaultJob [DocumentCount=1000]",
          "typeName": "IndexSortIndexBenchmarks",
          "methodName": "LeanCorpus_Index_Sorted",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 43667424.93333332,
            "medianNanoseconds": 43606260.75,
            "minNanoseconds": 43171134.166666664,
            "maxNanoseconds": 44102512.666666664,
            "standardDeviationNanoseconds": 240785.6168173676,
            "operationsPerSecond": 22.90036569655049
          },
          "gc": {
            "bytesAllocatedPerOperation": 9498373,
            "gen0Collections": 14,
            "gen1Collections": 11,
            "gen2Collections": 0
          }
        },
        {
          "key": "IndexSortIndexBenchmarks.LeanCorpus_Index_Unsorted|DocumentCount=1000",
          "displayInfo": "IndexSortIndexBenchmarks.LeanCorpus_Index_Unsorted: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "IndexSortIndexBenchmarks",
          "methodName": "LeanCorpus_Index_Unsorted",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 39462507.56410256,
            "medianNanoseconds": 39442288.84615385,
            "minNanoseconds": 39366812.538461536,
            "maxNanoseconds": 39578421.307692304,
            "standardDeviationNanoseconds": 107243.48567841956,
            "operationsPerSecond": 25.340508288167154
          },
          "gc": {
            "bytesAllocatedPerOperation": 9170266,
            "gen0Collections": 14,
            "gen1Collections": 12,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "indexsort-search",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.IndexSortSearchBenchmarks-20260522-152630",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "IndexSortSearchBenchmarks.LeanCorpus_SortedSearch_EarlyTermination|DocumentCount=1000",
          "displayInfo": "IndexSortSearchBenchmarks.LeanCorpus_SortedSearch_EarlyTermination: DefaultJob [DocumentCount=1000]",
          "typeName": "IndexSortSearchBenchmarks",
          "methodName": "LeanCorpus_SortedSearch_EarlyTermination",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 321.50323886871337,
            "medianNanoseconds": 321.4354567527771,
            "minNanoseconds": 320.67650413513184,
            "maxNanoseconds": 322.77845096588135,
            "standardDeviationNanoseconds": 0.6141734563908573,
            "operationsPerSecond": 3110388.571881083
          },
          "gc": {
            "bytesAllocatedPerOperation": 312,
            "gen0Collections": 156,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "IndexSortSearchBenchmarks.LeanCorpus_SortedSearch_PostSort|DocumentCount=1000",
          "displayInfo": "IndexSortSearchBenchmarks.LeanCorpus_SortedSearch_PostSort: DefaultJob [DocumentCount=1000]",
          "typeName": "IndexSortSearchBenchmarks",
          "methodName": "LeanCorpus_SortedSearch_PostSort",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 321.71137406275824,
            "medianNanoseconds": 321.69215393066406,
            "minNanoseconds": 321.1395573616028,
            "maxNanoseconds": 322.4967555999756,
            "standardDeviationNanoseconds": 0.40254574049636,
            "operationsPerSecond": 3108376.267122355
          },
          "gc": {
            "bytesAllocatedPerOperation": 312,
            "gen0Collections": 156,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "kstemmer",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.KStemmerParityBenchmarks-20260522-170152",
      "benchmarkCount": 1,
      "benchmarks": [
        {
          "key": "KStemmerParityBenchmarks.KStem_Analyse|DocumentCount=1000",
          "displayInfo": "KStemmerParityBenchmarks.KStem_Analyse: DefaultJob [DocumentCount=1000]",
          "typeName": "KStemmerParityBenchmarks",
          "methodName": "KStem_Analyse",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 9841991.274038462,
            "medianNanoseconds": 9840712.9375,
            "minNanoseconds": 9800098.25,
            "maxNanoseconds": 9914840.953125,
            "standardDeviationNanoseconds": 30301.81555017496,
            "operationsPerSecond": 101.60545484711349
          },
          "gc": {
            "bytesAllocatedPerOperation": 7207944,
            "gen0Collections": 110,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "lightenglish",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.LightEnglishStemmerBenchmarks-20260522-170330",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "LightEnglishStemmerBenchmarks.LightEnglish_Stem|DocumentCount=1000",
          "displayInfo": "LightEnglishStemmerBenchmarks.LightEnglish_Stem: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "LightEnglishStemmerBenchmarks",
          "methodName": "LightEnglish_Stem",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2577260.5703125,
            "medianNanoseconds": 2574492.64453125,
            "minNanoseconds": 2571285.2421875,
            "maxNanoseconds": 2586003.82421875,
            "standardDeviationNanoseconds": 7739.846516600969,
            "operationsPerSecond": 388.008884906328
          },
          "gc": {
            "bytesAllocatedPerOperation": 399000,
            "gen0Collections": 24,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "LightEnglishStemmerBenchmarks.Porter_Stem|DocumentCount=1000",
          "displayInfo": "LightEnglishStemmerBenchmarks.Porter_Stem: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "LightEnglishStemmerBenchmarks",
          "methodName": "Porter_Stem",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 3497107.7513020835,
            "medianNanoseconds": 3497290.01953125,
            "minNanoseconds": 3492192.9609375,
            "maxNanoseconds": 3501840.2734375,
            "standardDeviationNanoseconds": 4826.238276202982,
            "operationsPerSecond": 285.95058291460094
          },
          "gc": {
            "bytesAllocatedPerOperation": 376928,
            "gen0Collections": 23,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "mlt",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.MoreLikeThisBenchmarks-20260522-161105",
      "benchmarkCount": 9,
      "benchmarks": [
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams|DocumentCount=1000, MaxQueryTerms=10",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxQueryTerms=10, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_DefaultParams",
          "parameters": {
            "MaxQueryTerms": "10",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 20397.77150472005,
            "medianNanoseconds": 20359.75537109375,
            "minNanoseconds": 20330.677490234375,
            "maxNanoseconds": 20502.88165283203,
            "standardDeviationNanoseconds": 92.18182150462015,
            "operationsPerSecond": 49024.96332840084
          },
          "gc": {
            "bytesAllocatedPerOperation": 15456,
            "gen0Collections": 121,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams|DocumentCount=1000, MaxQueryTerms=25",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams: DefaultJob [MaxQueryTerms=25, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_DefaultParams",
          "parameters": {
            "MaxQueryTerms": "25",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 39908.88594156901,
            "medianNanoseconds": 39882.205627441406,
            "minNanoseconds": 39766.753967285156,
            "maxNanoseconds": 40095.51385498047,
            "standardDeviationNanoseconds": 90.88289944394072,
            "operationsPerSecond": 25057.076297847798
          },
          "gc": {
            "bytesAllocatedPerOperation": 21864,
            "gen0Collections": 85,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams|DocumentCount=1000, MaxQueryTerms=50",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_DefaultParams: DefaultJob [MaxQueryTerms=50, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_DefaultParams",
          "parameters": {
            "MaxQueryTerms": "50",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 136388.67945963543,
            "medianNanoseconds": 136312.84790039062,
            "minNanoseconds": 135865.67529296875,
            "maxNanoseconds": 137123.189453125,
            "standardDeviationNanoseconds": 345.87913399714637,
            "operationsPerSecond": 7331.986818568417
          },
          "gc": {
            "bytesAllocatedPerOperation": 27784,
            "gen0Collections": 27,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq|DocumentCount=1000, MaxQueryTerms=10",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq: DefaultJob [MaxQueryTerms=10, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_HighMinDocFreq",
          "parameters": {
            "MaxQueryTerms": "10",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 6992.024136861165,
            "medianNanoseconds": 6990.750457763672,
            "minNanoseconds": 6972.070419311523,
            "maxNanoseconds": 7016.563758850098,
            "standardDeviationNanoseconds": 12.999767008702374,
            "operationsPerSecond": 143020.10125052521
          },
          "gc": {
            "bytesAllocatedPerOperation": 7064,
            "gen0Collections": 221,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq|DocumentCount=1000, MaxQueryTerms=25",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq: DefaultJob [MaxQueryTerms=25, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_HighMinDocFreq",
          "parameters": {
            "MaxQueryTerms": "25",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 6975.327062479655,
            "medianNanoseconds": 6972.070663452148,
            "minNanoseconds": 6943.199356079102,
            "maxNanoseconds": 7011.573623657227,
            "standardDeviationNanoseconds": 19.1365207895463,
            "operationsPerSecond": 143362.4532645944
          },
          "gc": {
            "bytesAllocatedPerOperation": 7064,
            "gen0Collections": 221,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq|DocumentCount=1000, MaxQueryTerms=50",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_HighMinDocFreq: DefaultJob [MaxQueryTerms=50, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_HighMinDocFreq",
          "parameters": {
            "MaxQueryTerms": "50",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 12,
            "meanNanoseconds": 7060.184228897095,
            "medianNanoseconds": 7060.716320037842,
            "minNanoseconds": 7051.205406188965,
            "maxNanoseconds": 7066.429901123047,
            "standardDeviationNanoseconds": 4.703358234297112,
            "operationsPerSecond": 141639.36344706613
          },
          "gc": {
            "bytesAllocatedPerOperation": 7064,
            "gen0Collections": 221,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost|DocumentCount=1000, MaxQueryTerms=10",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxQueryTerms=10, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_NoBoost",
          "parameters": {
            "MaxQueryTerms": "10",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 20271.497589111328,
            "medianNanoseconds": 20282.622924804688,
            "minNanoseconds": 20229.99526977539,
            "maxNanoseconds": 20301.874572753906,
            "standardDeviationNanoseconds": 37.208713628487125,
            "operationsPerSecond": 49330.34649285813
          },
          "gc": {
            "bytesAllocatedPerOperation": 15456,
            "gen0Collections": 121,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost|DocumentCount=1000, MaxQueryTerms=25",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [MaxQueryTerms=25, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_NoBoost",
          "parameters": {
            "MaxQueryTerms": "25",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 39650.46510823568,
            "medianNanoseconds": 39652.557067871094,
            "minNanoseconds": 39556.4697265625,
            "maxNanoseconds": 39742.36853027344,
            "standardDeviationNanoseconds": 92.96705613617426,
            "operationsPerSecond": 25220.385114531557
          },
          "gc": {
            "bytesAllocatedPerOperation": 21864,
            "gen0Collections": 85,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost|DocumentCount=1000, MaxQueryTerms=50",
          "displayInfo": "MoreLikeThisBenchmarks.LeanCorpus_MoreLikeThisQuery_NoBoost: DefaultJob [MaxQueryTerms=50, DocumentCount=1000]",
          "typeName": "MoreLikeThisBenchmarks",
          "methodName": "LeanCorpus_MoreLikeThisQuery_NoBoost",
          "parameters": {
            "MaxQueryTerms": "50",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 136874.33912760418,
            "medianNanoseconds": 136864.564453125,
            "minNanoseconds": 136375.29736328125,
            "maxNanoseconds": 137785.193359375,
            "standardDeviationNanoseconds": 386.0673490752265,
            "operationsPerSecond": 7305.971348418549
          },
          "gc": {
            "bytesAllocatedPerOperation": 27784,
            "gen0Collections": 27,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "multiphrase",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.MultiPhraseQueryBenchmarks-20260522-160404",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "MultiPhraseQueryBenchmarks.LeanCorpus_MultiPhraseQuery|DocumentCount=1000",
          "displayInfo": "MultiPhraseQueryBenchmarks.LeanCorpus_MultiPhraseQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "MultiPhraseQueryBenchmarks",
          "methodName": "LeanCorpus_MultiPhraseQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1056.08651860555,
            "medianNanoseconds": 1054.921100616455,
            "minNanoseconds": 1052.3124160766602,
            "maxNanoseconds": 1061.0260391235352,
            "standardDeviationNanoseconds": 4.4721869334518605,
            "operationsPerSecond": 946892.1176272505
          },
          "gc": {
            "bytesAllocatedPerOperation": 2664,
            "gen0Collections": 333,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "MultiPhraseQueryBenchmarks.LuceneNet_MultiPhraseQuery|DocumentCount=1000",
          "displayInfo": "MultiPhraseQueryBenchmarks.LuceneNet_MultiPhraseQuery: DefaultJob [DocumentCount=1000]",
          "typeName": "MultiPhraseQueryBenchmarks",
          "methodName": "LuceneNet_MultiPhraseQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 11148.743150838216,
            "medianNanoseconds": 11142.238052368164,
            "minNanoseconds": 11110.636459350586,
            "maxNanoseconds": 11199.330596923828,
            "standardDeviationNanoseconds": 24.340645271765126,
            "operationsPerSecond": 89696.20938166606
          },
          "gc": {
            "bytesAllocatedPerOperation": 31952,
            "gen0Collections": 500,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "ngram",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.NGramTokeniserBenchmarks-20260522-170754",
      "benchmarkCount": 16,
      "benchmarks": [
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_SpanSink|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_SpanSink: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_EdgeNGramTokeniser_SpanSink",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 833800.5485026041,
            "medianNanoseconds": 833857.4072265625,
            "minNanoseconds": 833237.1943359375,
            "maxNanoseconds": 834307.0439453125,
            "standardDeviationNanoseconds": 537.1864039023953,
            "operationsPerSecond": 1199.3275871500302
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_SpanSink|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_SpanSink: DefaultJob [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_EdgeNGramTokeniser_SpanSink",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 860124.3176618303,
            "medianNanoseconds": 860140.9536132812,
            "minNanoseconds": 858578.4853515625,
            "maxNanoseconds": 862080.443359375,
            "standardDeviationNanoseconds": 1032.5173007840294,
            "operationsPerSecond": 1162.622634270368
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_Streaming|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_Streaming: DefaultJob [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_EdgeNGramTokeniser_Streaming",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1161184.0425502232,
            "medianNanoseconds": 1160768.193359375,
            "minNanoseconds": 1159459.28515625,
            "maxNanoseconds": 1164653.107421875,
            "standardDeviationNanoseconds": 1525.4545345105778,
            "operationsPerSecond": 861.1899262788468
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_Streaming|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_EdgeNGramTokeniser_Streaming: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_EdgeNGramTokeniser_Streaming",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1228861.7141927083,
            "medianNanoseconds": 1227936.431640625,
            "minNanoseconds": 1226105.55078125,
            "maxNanoseconds": 1232543.16015625,
            "standardDeviationNanoseconds": 3317.049060108149,
            "operationsPerSecond": 813.7612136911131
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_SpanSink|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_SpanSink: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_SpanSink",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 810173.1243489584,
            "medianNanoseconds": 810055.3486328125,
            "minNanoseconds": 809942.4453125,
            "maxNanoseconds": 810521.5791015625,
            "standardDeviationNanoseconds": 307.00541671722993,
            "operationsPerSecond": 1234.3040887755728
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_SpanSink|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_SpanSink: DefaultJob [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_SpanSink",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 1221507.1502403845,
            "medianNanoseconds": 1221118.439453125,
            "minNanoseconds": 1220389.900390625,
            "maxNanoseconds": 1224157.587890625,
            "standardDeviationNanoseconds": 1110.9263875669567,
            "operationsPerSecond": 818.6607829542436
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_Streaming|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_Streaming: DefaultJob [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_Streaming",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 2727894.6984375,
            "medianNanoseconds": 2727581.20703125,
            "minNanoseconds": 2723376.140625,
            "maxNanoseconds": 2734929.45703125,
            "standardDeviationNanoseconds": 3198.0261111816862,
            "operationsPerSecond": 366.5830651647903
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_Streaming|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_Streaming: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_Streaming",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 3856015.33203125,
            "medianNanoseconds": 3856511.98046875,
            "minNanoseconds": 3852905.49609375,
            "maxNanoseconds": 3858628.51953125,
            "standardDeviationNanoseconds": 2893.6558311929516,
            "operationsPerSecond": 259.33506843014175
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_SpanSink|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_SpanSink: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_WordSplit_SpanSink",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1218527.2955729167,
            "medianNanoseconds": 1218753.869140625,
            "minNanoseconds": 1215606.62890625,
            "maxNanoseconds": 1221221.388671875,
            "standardDeviationNanoseconds": 2814.2287562684714,
            "operationsPerSecond": 820.6627817309817
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_SpanSink|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_SpanSink: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_WordSplit_SpanSink",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1234887.2903645833,
            "medianNanoseconds": 1233719.78515625,
            "minNanoseconds": 1233045.8515625,
            "maxNanoseconds": 1237896.234375,
            "standardDeviationNanoseconds": 2627.5187279185943,
            "operationsPerSecond": 809.7905029897619
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_Streaming|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_Streaming: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_WordSplit_Streaming",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2738714.0325520835,
            "medianNanoseconds": 2739174.45703125,
            "minNanoseconds": 2736518.90234375,
            "maxNanoseconds": 2740448.73828125,
            "standardDeviationNanoseconds": 2004.967742802499,
            "operationsPerSecond": 365.1348728323217
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_Streaming|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LeanCorpus_NGramTokeniser_WordSplit_Streaming: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LeanCorpus_NGramTokeniser_WordSplit_Streaming",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2602939.71484375,
            "medianNanoseconds": 2601091.44921875,
            "minNanoseconds": 2599344.68359375,
            "maxNanoseconds": 2608383.01171875,
            "standardDeviationNanoseconds": 4794.257835078229,
            "operationsPerSecond": 384.18100668921113
          },
          "gc": {
            "bytesAllocatedPerOperation": 0,
            "gen0Collections": 0,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LuceneNet_EdgeNGramTokenizer|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LuceneNet_EdgeNGramTokenizer: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LuceneNet_EdgeNGramTokenizer",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 4092338.1744791665,
            "medianNanoseconds": 4090612.890625,
            "minNanoseconds": 4088190.28125,
            "maxNanoseconds": 4098211.3515625,
            "standardDeviationNanoseconds": 5228.567283214719,
            "operationsPerSecond": 244.3590821101363
          },
          "gc": {
            "bytesAllocatedPerOperation": 8856000,
            "gen0Collections": 271,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LuceneNet_EdgeNGramTokenizer|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LuceneNet_EdgeNGramTokenizer: DefaultJob [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LuceneNet_EdgeNGramTokenizer",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 4189153.9125,
            "medianNanoseconds": 4189513.15625,
            "minNanoseconds": 4170882.34375,
            "maxNanoseconds": 4224815.6796875,
            "standardDeviationNanoseconds": 16756.030172479557,
            "operationsPerSecond": 238.71168758352465
          },
          "gc": {
            "bytesAllocatedPerOperation": 8880000,
            "gen0Collections": 271,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LuceneNet_NGramTokenizer|DocumentCount=1000, GramRange=2-3",
          "displayInfo": "NGramTokeniserBenchmarks.LuceneNet_NGramTokenizer: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [GramRange=2-3, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LuceneNet_NGramTokenizer",
          "parameters": {
            "GramRange": "2-3",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 17223654.34375,
            "medianNanoseconds": 17243976.84375,
            "minNanoseconds": 17176886.84375,
            "maxNanoseconds": 17250099.34375,
            "standardDeviationNanoseconds": 40617.367513786514,
            "operationsPerSecond": 58.05968814991187
          },
          "gc": {
            "bytesAllocatedPerOperation": 8856000,
            "gen0Collections": 67,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "NGramTokeniserBenchmarks.LuceneNet_NGramTokenizer|DocumentCount=1000, GramRange=3-5",
          "displayInfo": "NGramTokeniserBenchmarks.LuceneNet_NGramTokenizer: DefaultJob [GramRange=3-5, DocumentCount=1000]",
          "typeName": "NGramTokeniserBenchmarks",
          "methodName": "LuceneNet_NGramTokenizer",
          "parameters": {
            "GramRange": "3-5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 26825938.90625,
            "medianNanoseconds": 26831745.8125,
            "minNanoseconds": 26721819.0625,
            "maxNanoseconds": 26918852.78125,
            "standardDeviationNanoseconds": 56930.6898383196,
            "operationsPerSecond": 37.277353217523974
          },
          "gc": {
            "bytesAllocatedPerOperation": 8880000,
            "gen0Collections": 67,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "parallel",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.ParallelSearchBenchmarks-20260522-163920",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch_BooleanQuery|DocumentCount=1000, SegmentCount=4",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch_BooleanQuery: DefaultJob [SegmentCount=4, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_ParallelSearch_BooleanQuery",
          "parameters": {
            "SegmentCount": "4",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 7644.102530343192,
            "medianNanoseconds": 7642.383007049561,
            "minNanoseconds": 7600.011291503906,
            "maxNanoseconds": 7688.465805053711,
            "standardDeviationNanoseconds": 23.366327843442512,
            "operationsPerSecond": 130819.8046834811
          },
          "gc": {
            "bytesAllocatedPerOperation": 8392,
            "gen0Collections": 266,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch_BooleanQuery|DocumentCount=1000, SegmentCount=8",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch_BooleanQuery: DefaultJob [SegmentCount=8, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_ParallelSearch_BooleanQuery",
          "parameters": {
            "SegmentCount": "8",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 10876.303491210938,
            "medianNanoseconds": 10877.56233215332,
            "minNanoseconds": 10764.202133178711,
            "maxNanoseconds": 11015.177551269531,
            "standardDeviationNanoseconds": 69.0839427577838,
            "operationsPerSecond": 91943.00258429647
          },
          "gc": {
            "bytesAllocatedPerOperation": 13192,
            "gen0Collections": 209,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch|DocumentCount=1000, SegmentCount=4",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch: DefaultJob [SegmentCount=4, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_ParallelSearch",
          "parameters": {
            "SegmentCount": "4",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 831.2602361951556,
            "medianNanoseconds": 831.4526500701904,
            "minNanoseconds": 829.3897743225098,
            "maxNanoseconds": 833.1272287368774,
            "standardDeviationNanoseconds": 1.1389099793137658,
            "operationsPerSecond": 1202992.7048804837
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 64,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch|DocumentCount=1000, SegmentCount=8",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_ParallelSearch: DefaultJob [SegmentCount=8, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_ParallelSearch",
          "parameters": {
            "SegmentCount": "8",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1504.853549194336,
            "medianNanoseconds": 1504.8545875549316,
            "minNanoseconds": 1499.1233654022217,
            "maxNanoseconds": 1513.0016059875488,
            "standardDeviationNanoseconds": 3.8113810040976093,
            "operationsPerSecond": 664516.4910136119
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 32,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_SequentialSearch|DocumentCount=1000, SegmentCount=4",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_SequentialSearch: DefaultJob [SegmentCount=4, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_SequentialSearch",
          "parameters": {
            "SegmentCount": "4",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 830.2559005101522,
            "medianNanoseconds": 830.7393798828125,
            "minNanoseconds": 827.2279348373413,
            "maxNanoseconds": 833.7513389587402,
            "standardDeviationNanoseconds": 1.7915040328968064,
            "operationsPerSecond": 1204447.9291090232
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 64,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "ParallelSearchBenchmarks.LeanCorpus_SequentialSearch|DocumentCount=1000, SegmentCount=8",
          "displayInfo": "ParallelSearchBenchmarks.LeanCorpus_SequentialSearch: DefaultJob [SegmentCount=8, DocumentCount=1000]",
          "typeName": "ParallelSearchBenchmarks",
          "methodName": "LeanCorpus_SequentialSearch",
          "parameters": {
            "SegmentCount": "8",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1507.894841257731,
            "medianNanoseconds": 1506.305377960205,
            "minNanoseconds": 1503.1976528167725,
            "maxNanoseconds": 1515.878179550171,
            "standardDeviationNanoseconds": 3.6512585385109695,
            "operationsPerSecond": 663176.219348229
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 32,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "phrase",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.PhraseQueryBenchmarks-20260522-145346",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery|DocumentCount=1000, PhraseType=ExactThreeWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [PhraseType=ExactThreeWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanCorpus_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactThreeWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2074.5251808166504,
            "medianNanoseconds": 2070.540744781494,
            "minNanoseconds": 2066.6231803894043,
            "maxNanoseconds": 2086.4116172790527,
            "standardDeviationNanoseconds": 10.478661962416219,
            "operationsPerSecond": 482038.01488991495
          },
          "gc": {
            "bytesAllocatedPerOperation": 3248,
            "gen0Collections": 203,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery|DocumentCount=1000, PhraseType=ExactTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [PhraseType=ExactTwoWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanCorpus_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactTwoWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1877.5296408335369,
            "medianNanoseconds": 1878.4992275238037,
            "minNanoseconds": 1873.1895332336426,
            "maxNanoseconds": 1880.900161743164,
            "standardDeviationNanoseconds": 3.9456966134535048,
            "operationsPerSecond": 532614.7605084125
          },
          "gc": {
            "bytesAllocatedPerOperation": 2936,
            "gen0Collections": 368,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery|DocumentCount=1000, PhraseType=SlopTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LeanCorpus_PhraseQuery: DefaultJob [PhraseType=SlopTwoWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LeanCorpus_PhraseQuery",
          "parameters": {
            "PhraseType": "SlopTwoWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 8463.444078572591,
            "medianNanoseconds": 8452.820220947266,
            "minNanoseconds": 8438.541030883789,
            "maxNanoseconds": 8502.08853149414,
            "standardDeviationNanoseconds": 22.747202433285008,
            "operationsPerSecond": 118155.2085316851
          },
          "gc": {
            "bytesAllocatedPerOperation": 2968,
            "gen0Collections": 46,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=1000, PhraseType=ExactThreeWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=ExactThreeWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactThreeWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 9161.631814575196,
            "medianNanoseconds": 9177.703582763672,
            "minNanoseconds": 9095.908752441406,
            "maxNanoseconds": 9258.589904785156,
            "standardDeviationNanoseconds": 54.78185011541356,
            "operationsPerSecond": 109150.86092077012
          },
          "gc": {
            "bytesAllocatedPerOperation": 26520,
            "gen0Collections": 415,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=1000, PhraseType=ExactTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=ExactTwoWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "ExactTwoWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 6592.3384958903,
            "medianNanoseconds": 6589.0473709106445,
            "minNanoseconds": 6571.945640563965,
            "maxNanoseconds": 6618.29963684082,
            "standardDeviationNanoseconds": 15.21877450891584,
            "operationsPerSecond": 151691.2398572078
          },
          "gc": {
            "bytesAllocatedPerOperation": 19432,
            "gen0Collections": 609,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery|DocumentCount=1000, PhraseType=SlopTwoWord",
          "displayInfo": "PhraseQueryBenchmarks.LuceneNet_PhraseQuery: DefaultJob [PhraseType=SlopTwoWord, DocumentCount=1000]",
          "typeName": "PhraseQueryBenchmarks",
          "methodName": "LuceneNet_PhraseQuery",
          "parameters": {
            "PhraseType": "SlopTwoWord",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 6539.520707350511,
            "medianNanoseconds": 6540.615135192871,
            "minNanoseconds": 6523.76350402832,
            "maxNanoseconds": 6552.256202697754,
            "standardDeviationNanoseconds": 8.885435946847572,
            "operationsPerSecond": 152916.4054601106
          },
          "gc": {
            "bytesAllocatedPerOperation": 20152,
            "gen0Collections": 631,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "prefix",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.PrefixQueryBenchmarks-20260522-145821",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery|DocumentCount=1000, QueryPrefix=gov",
          "displayInfo": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery: DefaultJob [QueryPrefix=gov, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanCorpus_PrefixQuery",
          "parameters": {
            "QueryPrefix": "gov",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 474.28365775517057,
            "medianNanoseconds": 473.8142328262329,
            "minNanoseconds": 473.23968601226807,
            "maxNanoseconds": 476.2211380004883,
            "standardDeviationNanoseconds": 1.0067779107275505,
            "operationsPerSecond": 2108442.877271156
          },
          "gc": {
            "bytesAllocatedPerOperation": 488,
            "gen0Collections": 122,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery|DocumentCount=1000, QueryPrefix=mark",
          "displayInfo": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [QueryPrefix=mark, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanCorpus_PrefixQuery",
          "parameters": {
            "QueryPrefix": "mark",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1435.3186480204265,
            "medianNanoseconds": 1434.988447189331,
            "minNanoseconds": 1431.0445594787598,
            "maxNanoseconds": 1439.9229373931885,
            "standardDeviationNanoseconds": 4.448389937887183,
            "operationsPerSecond": 696709.4041307047
          },
          "gc": {
            "bytesAllocatedPerOperation": 656,
            "gen0Collections": 82,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery|DocumentCount=1000, QueryPrefix=pres",
          "displayInfo": "PrefixQueryBenchmarks.LeanCorpus_PrefixQuery: DefaultJob [QueryPrefix=pres, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LeanCorpus_PrefixQuery",
          "parameters": {
            "QueryPrefix": "pres",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 4058.9576563517253,
            "medianNanoseconds": 4054.5880279541016,
            "minNanoseconds": 4047.7037200927734,
            "maxNanoseconds": 4074.921516418457,
            "standardDeviationNanoseconds": 10.712270790322808,
            "operationsPerSecond": 246368.67015233182
          },
          "gc": {
            "bytesAllocatedPerOperation": 1008,
            "gen0Collections": 31,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=1000, QueryPrefix=gov",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [QueryPrefix=gov, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "gov",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 28199.815887451172,
            "medianNanoseconds": 28215.06298828125,
            "minNanoseconds": 28162.30874633789,
            "maxNanoseconds": 28222.075927734375,
            "standardDeviationNanoseconds": 32.67085177665244,
            "operationsPerSecond": 35461.22442753241
          },
          "gc": {
            "bytesAllocatedPerOperation": 125096,
            "gen0Collections": 978,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=1000, QueryPrefix=mark",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: DefaultJob [QueryPrefix=mark, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "mark",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 9956.477956136068,
            "medianNanoseconds": 9943.233154296875,
            "minNanoseconds": 9930.428466796875,
            "maxNanoseconds": 10006.505920410156,
            "standardDeviationNanoseconds": 25.7588894319104,
            "operationsPerSecond": 100437.12288678458
          },
          "gc": {
            "bytesAllocatedPerOperation": 52544,
            "gen0Collections": 819,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery|DocumentCount=1000, QueryPrefix=pres",
          "displayInfo": "PrefixQueryBenchmarks.LuceneNet_PrefixQuery: DefaultJob [QueryPrefix=pres, DocumentCount=1000]",
          "typeName": "PrefixQueryBenchmarks",
          "methodName": "LuceneNet_PrefixQuery",
          "parameters": {
            "QueryPrefix": "pres",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 11936.646402994791,
            "medianNanoseconds": 11932.351303100586,
            "minNanoseconds": 11892.231903076172,
            "maxNanoseconds": 11985.180191040039,
            "standardDeviationNanoseconds": 30.09497766940674,
            "operationsPerSecond": 83775.62392642455
          },
          "gc": {
            "bytesAllocatedPerOperation": 53040,
            "gen0Collections": 829,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "query",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.TermQueryBenchmarks-20260522-142711",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "TermQueryBenchmarks.LeanCorpus_TermQuery|DocumentCount=1000, QueryTerm=government",
          "displayInfo": "TermQueryBenchmarks.LeanCorpus_TermQuery: DefaultJob [QueryTerm=government, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanCorpus_TermQuery",
          "parameters": {
            "QueryTerm": "government",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 309.48372824986774,
            "medianNanoseconds": 309.308798789978,
            "minNanoseconds": 308.4769186973572,
            "maxNanoseconds": 311.2025394439697,
            "standardDeviationNanoseconds": 0.8173711767333756,
            "operationsPerSecond": 3231187.6480712113
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LeanCorpus_TermQuery|DocumentCount=1000, QueryTerm=people",
          "displayInfo": "TermQueryBenchmarks.LeanCorpus_TermQuery: DefaultJob [QueryTerm=people, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanCorpus_TermQuery",
          "parameters": {
            "QueryTerm": "people",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1121.4264279683432,
            "medianNanoseconds": 1120.246925354004,
            "minNanoseconds": 1118.353120803833,
            "maxNanoseconds": 1125.9638481140137,
            "standardDeviationNanoseconds": 2.6728322337497774,
            "operationsPerSecond": 891721.4496288196
          },
          "gc": {
            "bytesAllocatedPerOperation": 424,
            "gen0Collections": 53,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LeanCorpus_TermQuery|DocumentCount=1000, QueryTerm=said",
          "displayInfo": "TermQueryBenchmarks.LeanCorpus_TermQuery: DefaultJob [QueryTerm=said, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LeanCorpus_TermQuery",
          "parameters": {
            "QueryTerm": "said",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 12588.385010782878,
            "medianNanoseconds": 12577.882278442383,
            "minNanoseconds": 12524.555938720703,
            "maxNanoseconds": 12651.235549926758,
            "standardDeviationNanoseconds": 41.826038494534124,
            "operationsPerSecond": 79438.3075464745
          },
          "gc": {
            "bytesAllocatedPerOperation": 464,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=1000, QueryTerm=government",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: DefaultJob [QueryTerm=government, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "government",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 2762.211237080892,
            "medianNanoseconds": 2760.7660903930664,
            "minNanoseconds": 2755.240562438965,
            "maxNanoseconds": 2772.3939666748047,
            "standardDeviationNanoseconds": 5.934288044134907,
            "operationsPerSecond": 362028.79293793667
          },
          "gc": {
            "bytesAllocatedPerOperation": 8544,
            "gen0Collections": 535,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=1000, QueryTerm=people",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [QueryTerm=people, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "people",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 7728.579945882161,
            "medianNanoseconds": 7707.129867553711,
            "minNanoseconds": 7706.721038818359,
            "maxNanoseconds": 7771.888931274414,
            "standardDeviationNanoseconds": 37.507238594882914,
            "operationsPerSecond": 129389.87588952958
          },
          "gc": {
            "bytesAllocatedPerOperation": 13208,
            "gen0Collections": 206,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermQueryBenchmarks.LuceneNet_TermQuery|DocumentCount=1000, QueryTerm=said",
          "displayInfo": "TermQueryBenchmarks.LuceneNet_TermQuery: DefaultJob [QueryTerm=said, DocumentCount=1000]",
          "typeName": "TermQueryBenchmarks",
          "methodName": "LuceneNet_TermQuery",
          "parameters": {
            "QueryTerm": "said",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 19377.429007393974,
            "medianNanoseconds": 19377.30628967285,
            "minNanoseconds": 19302.98013305664,
            "maxNanoseconds": 19445.57647705078,
            "standardDeviationNanoseconds": 45.34378646409991,
            "operationsPerSecond": 51606.433424084455
          },
          "gc": {
            "bytesAllocatedPerOperation": 13072,
            "gen0Collections": 102,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "query-cache",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.QueryCacheBenchmarks-20260522-163601",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "QueryCacheBenchmarks.LeanCorpus_NoCache_BooleanQuery|DocumentCount=1000",
          "displayInfo": "QueryCacheBenchmarks.LeanCorpus_NoCache_BooleanQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "QueryCacheBenchmarks",
          "methodName": "LeanCorpus_NoCache_BooleanQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 1511.6805839538574,
            "medianNanoseconds": 1513.3449115753174,
            "minNanoseconds": 1507.5526714324951,
            "maxNanoseconds": 1514.1441688537598,
            "standardDeviationNanoseconds": 3.5971446158447056,
            "operationsPerSecond": 661515.4091510936
          },
          "gc": {
            "bytesAllocatedPerOperation": 1936,
            "gen0Collections": 242,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "QueryCacheBenchmarks.LeanCorpus_NoCache|DocumentCount=1000",
          "displayInfo": "QueryCacheBenchmarks.LeanCorpus_NoCache: DefaultJob [DocumentCount=1000]",
          "typeName": "QueryCacheBenchmarks",
          "methodName": "LeanCorpus_NoCache",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 305.2608827908834,
            "medianNanoseconds": 305.13751220703125,
            "minNanoseconds": 304.3043575286865,
            "maxNanoseconds": 306.44241094589233,
            "standardDeviationNanoseconds": 0.6310808955678507,
            "operationsPerSecond": 3275886.4839064307
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "QueryCacheBenchmarks.LeanCorpus_WithCache_BooleanQuery|DocumentCount=1000",
          "displayInfo": "QueryCacheBenchmarks.LeanCorpus_WithCache_BooleanQuery: DefaultJob [DocumentCount=1000]",
          "typeName": "QueryCacheBenchmarks",
          "methodName": "LeanCorpus_WithCache_BooleanQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 741.2777001063029,
            "medianNanoseconds": 741.1583957672119,
            "minNanoseconds": 739.1770105361938,
            "maxNanoseconds": 743.6102657318115,
            "standardDeviationNanoseconds": 1.3893058072076392,
            "operationsPerSecond": 1349022.1004309114
          },
          "gc": {
            "bytesAllocatedPerOperation": 1056,
            "gen0Collections": 264,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "QueryCacheBenchmarks.LeanCorpus_WithCache|DocumentCount=1000",
          "displayInfo": "QueryCacheBenchmarks.LeanCorpus_WithCache: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "QueryCacheBenchmarks",
          "methodName": "LeanCorpus_WithCache",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 278.23059209187824,
            "medianNanoseconds": 278.2422261238098,
            "minNanoseconds": 277.5495858192444,
            "maxNanoseconds": 278.89996433258057,
            "standardDeviationNanoseconds": 0.6752644262392677,
            "operationsPerSecond": 3594141.0773038813
          },
          "gc": {
            "bytesAllocatedPerOperation": 496,
            "gen0Collections": 248,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "range",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.RangeQueryBenchmarks-20260522-155001",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "RangeQueryBenchmarks.LeanCorpus_RangeQuery|DocumentCount=1000, RangeWidth=0.01",
          "displayInfo": "RangeQueryBenchmarks.LeanCorpus_RangeQuery: DefaultJob [RangeWidth=0.01, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LeanCorpus_RangeQuery",
          "parameters": {
            "RangeWidth": "0.01",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 2484.4974853515623,
            "medianNanoseconds": 2483.4345207214355,
            "minNanoseconds": 2479.165180206299,
            "maxNanoseconds": 2494.7812118530273,
            "standardDeviationNanoseconds": 5.08198173072554,
            "operationsPerSecond": 402495.87930595054
          },
          "gc": {
            "bytesAllocatedPerOperation": 840,
            "gen0Collections": 52,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RangeQueryBenchmarks.LeanCorpus_RangeQuery|DocumentCount=1000, RangeWidth=0.1",
          "displayInfo": "RangeQueryBenchmarks.LeanCorpus_RangeQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [RangeWidth=0.1, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LeanCorpus_RangeQuery",
          "parameters": {
            "RangeWidth": "0.1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 4590.887293497722,
            "medianNanoseconds": 4584.600303649902,
            "minNanoseconds": 4581.953330993652,
            "maxNanoseconds": 4606.108245849609,
            "standardDeviationNanoseconds": 13.248005847468814,
            "operationsPerSecond": 217822.81639027482
          },
          "gc": {
            "bytesAllocatedPerOperation": 952,
            "gen0Collections": 29,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RangeQueryBenchmarks.LeanCorpus_RangeQuery|DocumentCount=1000, RangeWidth=0.5",
          "displayInfo": "RangeQueryBenchmarks.LeanCorpus_RangeQuery: DefaultJob [RangeWidth=0.5, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LeanCorpus_RangeQuery",
          "parameters": {
            "RangeWidth": "0.5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 10193.716070992607,
            "medianNanoseconds": 10192.767379760742,
            "minNanoseconds": 10178.076858520508,
            "maxNanoseconds": 10219.389511108398,
            "standardDeviationNanoseconds": 12.175779294443117,
            "operationsPerSecond": 98099.65208326875
          },
          "gc": {
            "bytesAllocatedPerOperation": 952,
            "gen0Collections": 14,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery|DocumentCount=1000, RangeWidth=0.01",
          "displayInfo": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [RangeWidth=0.01, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LuceneNet_NumericRangeQuery",
          "parameters": {
            "RangeWidth": "0.01",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 14264.023412068686,
            "medianNanoseconds": 14263.199249267578,
            "minNanoseconds": 14257.778335571289,
            "maxNanoseconds": 14271.092651367188,
            "standardDeviationNanoseconds": 6.695310636577946,
            "operationsPerSecond": 70106.44690571017
          },
          "gc": {
            "bytesAllocatedPerOperation": 55064,
            "gen0Collections": 862,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery|DocumentCount=1000, RangeWidth=0.1",
          "displayInfo": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [RangeWidth=0.1, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LuceneNet_NumericRangeQuery",
          "parameters": {
            "RangeWidth": "0.1",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 16559.683756510418,
            "medianNanoseconds": 16528.873992919922,
            "minNanoseconds": 16520.751403808594,
            "maxNanoseconds": 16629.425872802734,
            "standardDeviationNanoseconds": 60.53483461748485,
            "operationsPerSecond": 60387.62664213629
          },
          "gc": {
            "bytesAllocatedPerOperation": 53880,
            "gen0Collections": 420,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery|DocumentCount=1000, RangeWidth=0.5",
          "displayInfo": "RangeQueryBenchmarks.LuceneNet_NumericRangeQuery: DefaultJob [RangeWidth=0.5, DocumentCount=1000]",
          "typeName": "RangeQueryBenchmarks",
          "methodName": "LuceneNet_NumericRangeQuery",
          "parameters": {
            "RangeWidth": "0.5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 28189.512865339006,
            "medianNanoseconds": 28191.89683532715,
            "minNanoseconds": 28070.444854736328,
            "maxNanoseconds": 28323.50457763672,
            "standardDeviationNanoseconds": 59.64289848276394,
            "operationsPerSecond": 35474.18519706208
          },
          "gc": {
            "bytesAllocatedPerOperation": 58312,
            "gen0Collections": 455,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "regexp",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.RegexpQueryBenchmarks-20260522-155440",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery|DocumentCount=1000, Pattern=.*nation.*",
          "displayInfo": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Pattern=.*nation.*, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LeanCorpus_RegexpQuery",
          "parameters": {
            "Pattern": ".*nation.*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 398339.26774088544,
            "medianNanoseconds": 398758.60009765625,
            "minNanoseconds": 397120.57861328125,
            "maxNanoseconds": 399138.62451171875,
            "standardDeviationNanoseconds": 1072.38380775091,
            "operationsPerSecond": 2510.422850529733
          },
          "gc": {
            "bytesAllocatedPerOperation": 2768,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery|DocumentCount=1000, Pattern=gov.*ment",
          "displayInfo": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery: DefaultJob [Pattern=gov.*ment, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LeanCorpus_RegexpQuery",
          "parameters": {
            "Pattern": "gov.*ment",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1828.481397374471,
            "medianNanoseconds": 1828.7901229858398,
            "minNanoseconds": 1822.862024307251,
            "maxNanoseconds": 1833.4803104400635,
            "standardDeviationNanoseconds": 3.508753524398881,
            "operationsPerSecond": 546901.9271598315
          },
          "gc": {
            "bytesAllocatedPerOperation": 2320,
            "gen0Collections": 290,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery|DocumentCount=1000, Pattern=mark.*",
          "displayInfo": "RegexpQueryBenchmarks.LeanCorpus_RegexpQuery: DefaultJob [Pattern=mark.*, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LeanCorpus_RegexpQuery",
          "parameters": {
            "Pattern": "mark.*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 3946.819564819336,
            "medianNanoseconds": 3944.342948913574,
            "minNanoseconds": 3933.199432373047,
            "maxNanoseconds": 3960.4274291992188,
            "standardDeviationNanoseconds": 10.014867854508582,
            "operationsPerSecond": 253368.56260510976
          },
          "gc": {
            "bytesAllocatedPerOperation": 3864,
            "gen0Collections": 121,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery|DocumentCount=1000, Pattern=.*nation.*",
          "displayInfo": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery: DefaultJob [Pattern=.*nation.*, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LuceneNet_RegexpQuery",
          "parameters": {
            "Pattern": ".*nation.*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 565097.8792067308,
            "medianNanoseconds": 564912.09765625,
            "minNanoseconds": 563916.4775390625,
            "maxNanoseconds": 567410.482421875,
            "standardDeviationNanoseconds": 927.357216059219,
            "operationsPerSecond": 1769.6049424283333
          },
          "gc": {
            "bytesAllocatedPerOperation": 415576,
            "gen0Collections": 101,
            "gen1Collections": 14,
            "gen2Collections": 0
          }
        },
        {
          "key": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery|DocumentCount=1000, Pattern=gov.*ment",
          "displayInfo": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Pattern=gov.*ment, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LuceneNet_RegexpQuery",
          "parameters": {
            "Pattern": "gov.*ment",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 268504.82535807294,
            "medianNanoseconds": 268558.2451171875,
            "minNanoseconds": 267966.40478515625,
            "maxNanoseconds": 268989.826171875,
            "standardDeviationNanoseconds": 513.7977098978035,
            "operationsPerSecond": 3724.3278539460844
          },
          "gc": {
            "bytesAllocatedPerOperation": 395400,
            "gen0Collections": 193,
            "gen1Collections": 30,
            "gen2Collections": 0
          }
        },
        {
          "key": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery|DocumentCount=1000, Pattern=mark.*",
          "displayInfo": "RegexpQueryBenchmarks.LuceneNet_RegexpQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Pattern=mark.*, DocumentCount=1000]",
          "typeName": "RegexpQueryBenchmarks",
          "methodName": "LuceneNet_RegexpQuery",
          "parameters": {
            "Pattern": "mark.*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 51535.65883382162,
            "medianNanoseconds": 51536.334045410156,
            "minNanoseconds": 51425.725830078125,
            "maxNanoseconds": 51644.91662597656,
            "standardDeviationNanoseconds": 109.59695791701792,
            "operationsPerSecond": 19404.040282564973
          },
          "gc": {
            "bytesAllocatedPerOperation": 104104,
            "gen0Collections": 407,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "schemajson",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SchemaAndJsonBenchmarks-20260522-152035",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "SchemaAndJsonBenchmarks.LeanCorpus_Index_NoSchema|DocumentCount=1000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanCorpus_Index_NoSchema: DefaultJob [DocumentCount=1000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanCorpus_Index_NoSchema",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 69,
            "meanNanoseconds": 36601300.6304348,
            "medianNanoseconds": 35268306.5,
            "minNanoseconds": 34319824.71428572,
            "maxNanoseconds": 38874288.071428575,
            "standardDeviationNanoseconds": 1766613.0691630063,
            "operationsPerSecond": 27.32143346754398
          },
          "gc": {
            "bytesAllocatedPerOperation": 8314664,
            "gen0Collections": 14,
            "gen1Collections": 13,
            "gen2Collections": 0
          }
        },
        {
          "key": "SchemaAndJsonBenchmarks.LeanCorpus_Index_WithSchema|DocumentCount=1000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanCorpus_Index_WithSchema: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanCorpus_Index_WithSchema",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 36582603.52380952,
            "medianNanoseconds": 35958322.71428572,
            "minNanoseconds": 35805399.64285714,
            "maxNanoseconds": 37984088.21428572,
            "standardDeviationNanoseconds": 1216127.4068423698,
            "operationsPerSecond": 27.335397256489884
          },
          "gc": {
            "bytesAllocatedPerOperation": 8355008,
            "gen0Collections": 14,
            "gen1Collections": 13,
            "gen2Collections": 0
          }
        },
        {
          "key": "SchemaAndJsonBenchmarks.LeanCorpus_JsonMapping|DocumentCount=1000",
          "displayInfo": "SchemaAndJsonBenchmarks.LeanCorpus_JsonMapping: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SchemaAndJsonBenchmarks",
          "methodName": "LeanCorpus_JsonMapping",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2168640.2421875,
            "medianNanoseconds": 2170455.4453125,
            "minNanoseconds": 2164011.890625,
            "maxNanoseconds": 2171453.390625,
            "standardDeviationNanoseconds": 4039.208134183893,
            "operationsPerSecond": 461.11843751054965
          },
          "gc": {
            "bytesAllocatedPerOperation": 983416,
            "gen0Collections": 60,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "searcher-mgr",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SearcherManagerBenchmarks-20260522-162150",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "SearcherManagerBenchmarks.LeanCorpus_SearcherManager_AcquireLease|DocumentCount=1000",
          "displayInfo": "SearcherManagerBenchmarks.LeanCorpus_SearcherManager_AcquireLease: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SearcherManagerBenchmarks",
          "methodName": "LeanCorpus_SearcherManager_AcquireLease",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 324.9520428975423,
            "medianNanoseconds": 324.7682800292969,
            "minNanoseconds": 324.3701066970825,
            "maxNanoseconds": 325.71774196624756,
            "standardDeviationNanoseconds": 0.6923559767083157,
            "operationsPerSecond": 3077377.1756692757
          },
          "gc": {
            "bytesAllocatedPerOperation": 320,
            "gen0Collections": 160,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SearcherManagerBenchmarks.LeanCorpus_SearcherManager_AcquireSearch|DocumentCount=1000",
          "displayInfo": "SearcherManagerBenchmarks.LeanCorpus_SearcherManager_AcquireSearch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SearcherManagerBenchmarks",
          "methodName": "LeanCorpus_SearcherManager_AcquireSearch",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 335.407509803772,
            "medianNanoseconds": 334.84004640579224,
            "minNanoseconds": 334.77639389038086,
            "maxNanoseconds": 336.6060891151428,
            "standardDeviationNanoseconds": 1.0384879320022038,
            "operationsPerSecond": 2981447.853046116
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SearcherManagerBenchmarks.LuceneNet_SearcherManager_AcquireSearch|DocumentCount=1000",
          "displayInfo": "SearcherManagerBenchmarks.LuceneNet_SearcherManager_AcquireSearch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SearcherManagerBenchmarks",
          "methodName": "LuceneNet_SearcherManager_AcquireSearch",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 2914.038033803304,
            "medianNanoseconds": 2908.3507232666016,
            "minNanoseconds": 2905.6107864379883,
            "maxNanoseconds": 2928.1525917053223,
            "standardDeviationNanoseconds": 12.300096423738585,
            "operationsPerSecond": 343166.4200672198
          },
          "gc": {
            "bytesAllocatedPerOperation": 8544,
            "gen0Collections": 535,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "similarity",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SimilarityBenchmarks-20260522-165609",
      "benchmarkCount": 4,
      "benchmarks": [
        {
          "key": "SimilarityBenchmarks.LeanCorpus_Bm25_BooleanQuery|DocumentCount=1000",
          "displayInfo": "SimilarityBenchmarks.LeanCorpus_Bm25_BooleanQuery: DefaultJob [DocumentCount=1000]",
          "typeName": "SimilarityBenchmarks",
          "methodName": "LeanCorpus_Bm25_BooleanQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 1467.418397140503,
            "medianNanoseconds": 1466.9532260894775,
            "minNanoseconds": 1463.2051906585693,
            "maxNanoseconds": 1473.1013450622559,
            "standardDeviationNanoseconds": 2.823927065637364,
            "operationsPerSecond": 681468.8993600314
          },
          "gc": {
            "bytesAllocatedPerOperation": 1936,
            "gen0Collections": 242,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SimilarityBenchmarks.LeanCorpus_Bm25_TermQuery|DocumentCount=1000",
          "displayInfo": "SimilarityBenchmarks.LeanCorpus_Bm25_TermQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SimilarityBenchmarks",
          "methodName": "LeanCorpus_Bm25_TermQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 304.5815677642822,
            "medianNanoseconds": 304.283326625824,
            "minNanoseconds": 304.260938167572,
            "maxNanoseconds": 305.2004384994507,
            "standardDeviationNanoseconds": 0.5360746691475775,
            "operationsPerSecond": 3283192.7661949224
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SimilarityBenchmarks.LeanCorpus_TfIdf_BooleanQuery|DocumentCount=1000",
          "displayInfo": "SimilarityBenchmarks.LeanCorpus_TfIdf_BooleanQuery: DefaultJob [DocumentCount=1000]",
          "typeName": "SimilarityBenchmarks",
          "methodName": "LeanCorpus_TfIdf_BooleanQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1418.4342682702202,
            "medianNanoseconds": 1417.9706058502197,
            "minNanoseconds": 1414.6951389312744,
            "maxNanoseconds": 1424.725549697876,
            "standardDeviationNanoseconds": 2.5527472118514836,
            "operationsPerSecond": 705002.7078233942
          },
          "gc": {
            "bytesAllocatedPerOperation": 1936,
            "gen0Collections": 242,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SimilarityBenchmarks.LeanCorpus_TfIdf_TermQuery|DocumentCount=1000",
          "displayInfo": "SimilarityBenchmarks.LeanCorpus_TfIdf_TermQuery: DefaultJob [DocumentCount=1000]",
          "typeName": "SimilarityBenchmarks",
          "methodName": "LeanCorpus_TfIdf_TermQuery",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 304.5939605394999,
            "medianNanoseconds": 304.42622423171997,
            "minNanoseconds": 303.9279360771179,
            "maxNanoseconds": 305.8272247314453,
            "standardDeviationNanoseconds": 0.5813617249984754,
            "operationsPerSecond": 3283059.1855097516
          },
          "gc": {
            "bytesAllocatedPerOperation": 256,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "span",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SpanQueryBenchmarks-20260522-160618",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "SpanQueryBenchmarks.LeanCorpus_SpanQuery|DocumentCount=1000, SpanType=Near",
          "displayInfo": "SpanQueryBenchmarks.LeanCorpus_SpanQuery: DefaultJob [SpanType=Near, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LeanCorpus_SpanQuery",
          "parameters": {
            "SpanType": "Near",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 467.5739731788635,
            "medianNanoseconds": 467.3888695240021,
            "minNanoseconds": 466.4902572631836,
            "maxNanoseconds": 469.4385061264038,
            "standardDeviationNanoseconds": 0.8501275784653798,
            "operationsPerSecond": 2138699.0238172747
          },
          "gc": {
            "bytesAllocatedPerOperation": 1160,
            "gen0Collections": 581,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SpanQueryBenchmarks.LeanCorpus_SpanQuery|DocumentCount=1000, SpanType=Not",
          "displayInfo": "SpanQueryBenchmarks.LeanCorpus_SpanQuery: DefaultJob [SpanType=Not, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LeanCorpus_SpanQuery",
          "parameters": {
            "SpanType": "Not",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 714.3135396321615,
            "medianNanoseconds": 715.1784648895264,
            "minNanoseconds": 710.595552444458,
            "maxNanoseconds": 717.1691637039185,
            "standardDeviationNanoseconds": 2.310607118295661,
            "operationsPerSecond": 1399945.4644454226
          },
          "gc": {
            "bytesAllocatedPerOperation": 1248,
            "gen0Collections": 312,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SpanQueryBenchmarks.LeanCorpus_SpanQuery|DocumentCount=1000, SpanType=Or",
          "displayInfo": "SpanQueryBenchmarks.LeanCorpus_SpanQuery: DefaultJob [SpanType=Or, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LeanCorpus_SpanQuery",
          "parameters": {
            "SpanType": "Or",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 1527.5691702706474,
            "medianNanoseconds": 1527.2128257751465,
            "minNanoseconds": 1523.4100036621094,
            "maxNanoseconds": 1532.3452529907227,
            "standardDeviationNanoseconds": 2.730138384403591,
            "operationsPerSecond": 654634.8404130366
          },
          "gc": {
            "bytesAllocatedPerOperation": 1072,
            "gen0Collections": 134,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SpanQueryBenchmarks.LuceneNet_SpanQuery|DocumentCount=1000, SpanType=Near",
          "displayInfo": "SpanQueryBenchmarks.LuceneNet_SpanQuery: DefaultJob [SpanType=Near, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LuceneNet_SpanQuery",
          "parameters": {
            "SpanType": "Near",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 8466.72978515625,
            "medianNanoseconds": 8458.454650878906,
            "minNanoseconds": 8432.394241333008,
            "maxNanoseconds": 8519.856582641602,
            "standardDeviationNanoseconds": 24.23620489846298,
            "operationsPerSecond": 118109.35572234579
          },
          "gc": {
            "bytesAllocatedPerOperation": 21328,
            "gen0Collections": 334,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SpanQueryBenchmarks.LuceneNet_SpanQuery|DocumentCount=1000, SpanType=Not",
          "displayInfo": "SpanQueryBenchmarks.LuceneNet_SpanQuery: DefaultJob [SpanType=Not, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LuceneNet_SpanQuery",
          "parameters": {
            "SpanType": "Not",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 10858.04747554234,
            "medianNanoseconds": 10857.440559387207,
            "minNanoseconds": 10831.75131225586,
            "maxNanoseconds": 10891.98959350586,
            "standardDeviationNanoseconds": 19.333735354642563,
            "operationsPerSecond": 92097.58957607171
          },
          "gc": {
            "bytesAllocatedPerOperation": 27688,
            "gen0Collections": 433,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SpanQueryBenchmarks.LuceneNet_SpanQuery|DocumentCount=1000, SpanType=Or",
          "displayInfo": "SpanQueryBenchmarks.LuceneNet_SpanQuery: DefaultJob [SpanType=Or, DocumentCount=1000]",
          "typeName": "SpanQueryBenchmarks",
          "methodName": "LuceneNet_SpanQuery",
          "parameters": {
            "SpanType": "Or",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 15896.345408121744,
            "medianNanoseconds": 15898.186248779297,
            "minNanoseconds": 15830.245788574219,
            "maxNanoseconds": 15974.0791015625,
            "standardDeviationNanoseconds": 45.071969599362504,
            "operationsPerSecond": 62907.54096781774
          },
          "gc": {
            "bytesAllocatedPerOperation": 30224,
            "gen0Collections": 236,
            "gen1Collections": 1,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "stemmer",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.StemmerParityBenchmarks-20260522-165932",
      "benchmarkCount": 2,
      "benchmarks": [
        {
          "key": "StemmerParityBenchmarks.LeanCorpus_StemmedAnalyser|DocumentCount=1000",
          "displayInfo": "StemmerParityBenchmarks.LeanCorpus_StemmedAnalyser: DefaultJob [DocumentCount=1000]",
          "typeName": "StemmerParityBenchmarks",
          "methodName": "LeanCorpus_StemmedAnalyser",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 7435575.549479167,
            "medianNanoseconds": 7433652.5,
            "minNanoseconds": 7416685.4609375,
            "maxNanoseconds": 7461942.203125,
            "standardDeviationNanoseconds": 13396.96889789622,
            "operationsPerSecond": 134.48858038569
          },
          "gc": {
            "bytesAllocatedPerOperation": 398952,
            "gen0Collections": 12,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "StemmerParityBenchmarks.LuceneNet_EnglishAnalyzer|DocumentCount=1000",
          "displayInfo": "StemmerParityBenchmarks.LuceneNet_EnglishAnalyzer: DefaultJob [DocumentCount=1000]",
          "typeName": "StemmerParityBenchmarks",
          "methodName": "LuceneNet_EnglishAnalyzer",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 9549129.594791668,
            "medianNanoseconds": 9539964.6875,
            "minNanoseconds": 9501776.90625,
            "maxNanoseconds": 9589987.21875,
            "standardDeviationNanoseconds": 25155.538757753086,
            "operationsPerSecond": 104.72158640986764
          },
          "gc": {
            "bytesAllocatedPerOperation": 1661944,
            "gen0Collections": 25,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "suggester",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SuggesterBenchmarks-20260522-151732",
      "benchmarkCount": 3,
      "benchmarks": [
        {
          "key": "SuggesterBenchmarks.LeanCorpus_DidYouMean|DocumentCount=1000",
          "displayInfo": "SuggesterBenchmarks.LeanCorpus_DidYouMean: DefaultJob [DocumentCount=1000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LeanCorpus_DidYouMean",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 14,
            "meanNanoseconds": 202251.353515625,
            "medianNanoseconds": 202155.70239257812,
            "minNanoseconds": 201904.03393554688,
            "maxNanoseconds": 202932.54345703125,
            "standardDeviationNanoseconds": 288.6460078274874,
            "operationsPerSecond": 4944.342683584289
          },
          "gc": {
            "bytesAllocatedPerOperation": 7680,
            "gen0Collections": 7,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SuggesterBenchmarks.LeanCorpus_SpellIndex|DocumentCount=1000",
          "displayInfo": "SuggesterBenchmarks.LeanCorpus_SpellIndex: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [DocumentCount=1000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LeanCorpus_SpellIndex",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 200044.43977864584,
            "medianNanoseconds": 199893.78930664062,
            "minNanoseconds": 199829.2333984375,
            "maxNanoseconds": 200410.29663085938,
            "standardDeviationNanoseconds": 318.48122951703687,
            "operationsPerSecond": 4998.889252340755
          },
          "gc": {
            "bytesAllocatedPerOperation": 5920,
            "gen0Collections": 5,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SuggesterBenchmarks.LuceneNet_SpellChecker|DocumentCount=1000",
          "displayInfo": "SuggesterBenchmarks.LuceneNet_SpellChecker: DefaultJob [DocumentCount=1000]",
          "typeName": "SuggesterBenchmarks",
          "methodName": "LuceneNet_SpellChecker",
          "parameters": {
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 6150231.7515625,
            "medianNanoseconds": 6149468.421875,
            "minNanoseconds": 6128302.03125,
            "maxNanoseconds": 6172908.5,
            "standardDeviationNanoseconds": 14547.018610318111,
            "operationsPerSecond": 162.59549890066248
          },
          "gc": {
            "bytesAllocatedPerOperation": 5024200,
            "gen0Collections": 153,
            "gen1Collections": 2,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "synonym",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.SynonymBenchmarks-20260522-171739",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "SynonymBenchmarks.LeanCorpus_NoSynonyms|DocumentCount=1000, SynonymCount=10",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_NoSynonyms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SynonymCount=10, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_NoSynonyms",
          "parameters": {
            "SynonymCount": "10",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 4057687.8229166665,
            "medianNanoseconds": 4050699.984375,
            "minNanoseconds": 4049682.7421875,
            "maxNanoseconds": 4072680.7421875,
            "standardDeviationNanoseconds": 12994.20704057395,
            "operationsPerSecond": 246.4457700152004
          },
          "gc": {
            "bytesAllocatedPerOperation": 46400,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SynonymBenchmarks.LeanCorpus_NoSynonyms|DocumentCount=1000, SynonymCount=200",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_NoSynonyms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SynonymCount=200, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_NoSynonyms",
          "parameters": {
            "SynonymCount": "200",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 4076810.1588541665,
            "medianNanoseconds": 4074652.546875,
            "minNanoseconds": 4073943.578125,
            "maxNanoseconds": 4081834.3515625,
            "standardDeviationNanoseconds": 4365.494639782703,
            "operationsPerSecond": 245.28981263161424
          },
          "gc": {
            "bytesAllocatedPerOperation": 46400,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SynonymBenchmarks.LeanCorpus_NoSynonyms|DocumentCount=1000, SynonymCount=50",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_NoSynonyms: DefaultJob [SynonymCount=50, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_NoSynonyms",
          "parameters": {
            "SynonymCount": "50",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 4059219.2427884615,
            "medianNanoseconds": 4060142.109375,
            "minNanoseconds": 4045699.1015625,
            "maxNanoseconds": 4075255.34375,
            "standardDeviationNanoseconds": 7386.7461540311815,
            "operationsPerSecond": 246.35279352712536
          },
          "gc": {
            "bytesAllocatedPerOperation": 46400,
            "gen0Collections": 1,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SynonymBenchmarks.LeanCorpus_WithSynonyms|DocumentCount=1000, SynonymCount=10",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_WithSynonyms: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SynonymCount=10, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_WithSynonyms",
          "parameters": {
            "SynonymCount": "10",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 6585137.580729167,
            "medianNanoseconds": 6589236.328125,
            "minNanoseconds": 6563491.6796875,
            "maxNanoseconds": 6602684.734375,
            "standardDeviationNanoseconds": 19915.413166577273,
            "operationsPerSecond": 151.85711577635266
          },
          "gc": {
            "bytesAllocatedPerOperation": 3748792,
            "gen0Collections": 114,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SynonymBenchmarks.LeanCorpus_WithSynonyms|DocumentCount=1000, SynonymCount=200",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_WithSynonyms: DefaultJob [SynonymCount=200, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_WithSynonyms",
          "parameters": {
            "SynonymCount": "200",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 7239026.236778846,
            "medianNanoseconds": 7234164.921875,
            "minNanoseconds": 7222565.9609375,
            "maxNanoseconds": 7263114.6953125,
            "standardDeviationNanoseconds": 11787.413896634354,
            "operationsPerSecond": 138.1401264881961
          },
          "gc": {
            "bytesAllocatedPerOperation": 5966648,
            "gen0Collections": 182,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "SynonymBenchmarks.LeanCorpus_WithSynonyms|DocumentCount=1000, SynonymCount=50",
          "displayInfo": "SynonymBenchmarks.LeanCorpus_WithSynonyms: DefaultJob [SynonymCount=50, DocumentCount=1000]",
          "typeName": "SynonymBenchmarks",
          "methodName": "LeanCorpus_WithSynonyms",
          "parameters": {
            "SynonymCount": "50",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 12,
            "meanNanoseconds": 6790249.326171875,
            "medianNanoseconds": 6791948.33984375,
            "minNanoseconds": 6770918.3125,
            "maxNanoseconds": 6799463.7421875,
            "standardDeviationNanoseconds": 7059.8180525699745,
            "operationsPerSecond": 147.2699973100646
          },
          "gc": {
            "bytesAllocatedPerOperation": 4208072,
            "gen0Collections": 128,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "terminset",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.TermInSetQueryBenchmarks-20260522-162808",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should|DocumentCount=1000, SetSize=100",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should: DefaultJob [SetSize=100, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery_Should",
          "parameters": {
            "SetSize": "100",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 183533.13494466146,
            "medianNanoseconds": 183545.13403320312,
            "minNanoseconds": 183109.0830078125,
            "maxNanoseconds": 184073.93969726562,
            "standardDeviationNanoseconds": 342.3545475349401,
            "operationsPerSecond": 5448.6074152305955
          },
          "gc": {
            "bytesAllocatedPerOperation": 43872,
            "gen0Collections": 42,
            "gen1Collections": 3,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should|DocumentCount=1000, SetSize=20",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SetSize=20, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery_Should",
          "parameters": {
            "SetSize": "20",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 47685.19372558594,
            "medianNanoseconds": 47643.44073486328,
            "minNanoseconds": 47628.03820800781,
            "maxNanoseconds": 47784.10223388672,
            "standardDeviationNanoseconds": 86.00278611241409,
            "operationsPerSecond": 20970.870030531943
          },
          "gc": {
            "bytesAllocatedPerOperation": 9888,
            "gen0Collections": 38,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should|DocumentCount=1000, SetSize=5",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_BooleanQuery_Should: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SetSize=5, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_BooleanQuery_Should",
          "parameters": {
            "SetSize": "5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 21855.542572021484,
            "medianNanoseconds": 21822.508239746094,
            "minNanoseconds": 21800.158111572266,
            "maxNanoseconds": 21943.961364746094,
            "standardDeviationNanoseconds": 77.3840696623324,
            "operationsPerSecond": 45754.98396823864
          },
          "gc": {
            "bytesAllocatedPerOperation": 3368,
            "gen0Collections": 26,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery|DocumentCount=1000, SetSize=100",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery: DefaultJob [SetSize=100, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_TermInSetQuery",
          "parameters": {
            "SetSize": "100",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 45127.07500406901,
            "medianNanoseconds": 45117.88366699219,
            "minNanoseconds": 44992.116149902344,
            "maxNanoseconds": 45296.69464111328,
            "standardDeviationNanoseconds": 93.97079322254255,
            "operationsPerSecond": 22159.645842542024
          },
          "gc": {
            "bytesAllocatedPerOperation": 12040,
            "gen0Collections": 47,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery|DocumentCount=1000, SetSize=20",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SetSize=20, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_TermInSetQuery",
          "parameters": {
            "SetSize": "20",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 18840.911142985027,
            "medianNanoseconds": 18809.804565429688,
            "minNanoseconds": 18792.577667236328,
            "maxNanoseconds": 18920.351196289062,
            "standardDeviationNanoseconds": 69.33421274560062,
            "operationsPerSecond": 53075.98939408653
          },
          "gc": {
            "bytesAllocatedPerOperation": 3224,
            "gen0Collections": 25,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery|DocumentCount=1000, SetSize=5",
          "displayInfo": "TermInSetQueryBenchmarks.LeanCorpus_TermInSetQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [SetSize=5, DocumentCount=1000]",
          "typeName": "TermInSetQueryBenchmarks",
          "methodName": "LeanCorpus_TermInSetQuery",
          "parameters": {
            "SetSize": "5",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 10725.459309895834,
            "medianNanoseconds": 10727.04443359375,
            "minNanoseconds": 10698.463317871094,
            "maxNanoseconds": 10750.870178222656,
            "standardDeviationNanoseconds": 26.239363861006925,
            "operationsPerSecond": 93236.10030176993
          },
          "gc": {
            "bytesAllocatedPerOperation": 1520,
            "gen0Collections": 23,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        }
      ]
    },
    {
      "suiteName": "wildcard",
      "summaryTitle": "Rowles.LeanCorpus.Benchmarks.WildcardQueryBenchmarks-20260522-150958",
      "benchmarkCount": 6,
      "benchmarks": [
        {
          "key": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery|DocumentCount=1000, WildcardPattern=gov*",
          "displayInfo": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [WildcardPattern=gov*, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanCorpus_WildcardQuery",
          "parameters": {
            "WildcardPattern": "gov*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 498.6046676635742,
            "medianNanoseconds": 498.03371715545654,
            "minNanoseconds": 497.43093395233154,
            "maxNanoseconds": 500.34935188293457,
            "standardDeviationNanoseconds": 1.5407073591231362,
            "operationsPerSecond": 2005596.9485523037
          },
          "gc": {
            "bytesAllocatedPerOperation": 560,
            "gen0Collections": 140,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery|DocumentCount=1000, WildcardPattern=m*rket",
          "displayInfo": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery: DefaultJob [WildcardPattern=m*rket, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanCorpus_WildcardQuery",
          "parameters": {
            "WildcardPattern": "m*rket",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 12599.87319539388,
            "medianNanoseconds": 12593.19955444336,
            "minNanoseconds": 12558.77261352539,
            "maxNanoseconds": 12642.622848510742,
            "standardDeviationNanoseconds": 22.81568287245257,
            "operationsPerSecond": 79365.87809197705
          },
          "gc": {
            "bytesAllocatedPerOperation": 520,
            "gen0Collections": 8,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery|DocumentCount=1000, WildcardPattern=pre*dent",
          "displayInfo": "WildcardQueryBenchmarks.LeanCorpus_WildcardQuery: DefaultJob [WildcardPattern=pre*dent, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LeanCorpus_WildcardQuery",
          "parameters": {
            "WildcardPattern": "pre*dent",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 13,
            "meanNanoseconds": 3043.4410376915566,
            "medianNanoseconds": 3042.902130126953,
            "minNanoseconds": 3037.326229095459,
            "maxNanoseconds": 3051.401210784912,
            "standardDeviationNanoseconds": 3.5276754391166154,
            "operationsPerSecond": 328575.4472044899
          },
          "gc": {
            "bytesAllocatedPerOperation": 520,
            "gen0Collections": 32,
            "gen1Collections": 0,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=1000, WildcardPattern=gov*",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: DefaultJob [WildcardPattern=gov*, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "gov*",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 15,
            "meanNanoseconds": 40614.85927327474,
            "medianNanoseconds": 40639.072326660156,
            "minNanoseconds": 40392.84387207031,
            "maxNanoseconds": 40822.75616455078,
            "standardDeviationNanoseconds": 106.73015447424596,
            "operationsPerSecond": 24621.53058986509
          },
          "gc": {
            "bytesAllocatedPerOperation": 144576,
            "gen0Collections": 564,
            "gen1Collections": 113,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=1000, WildcardPattern=m*rket",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [WildcardPattern=m*rket, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "m*rket",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 206692.65877278647,
            "medianNanoseconds": 206468.8466796875,
            "minNanoseconds": 206426.32177734375,
            "maxNanoseconds": 207182.80786132812,
            "standardDeviationNanoseconds": 425.0137510463706,
            "operationsPerSecond": 4838.101197872161
          },
          "gc": {
            "bytesAllocatedPerOperation": 352952,
            "gen0Collections": 345,
            "gen1Collections": 5,
            "gen2Collections": 0
          }
        },
        {
          "key": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery|DocumentCount=1000, WildcardPattern=pre*dent",
          "displayInfo": "WildcardQueryBenchmarks.LuceneNet_WildcardQuery: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [WildcardPattern=pre*dent, DocumentCount=1000]",
          "typeName": "WildcardQueryBenchmarks",
          "methodName": "LuceneNet_WildcardQuery",
          "parameters": {
            "WildcardPattern": "pre*dent",
            "DocumentCount": "1000"
          },
          "statistics": {
            "sampleCount": 3,
            "meanNanoseconds": 228792.58601888022,
            "medianNanoseconds": 228621.67529296875,
            "minNanoseconds": 228618.27392578125,
            "maxNanoseconds": 229137.80883789062,
            "standardDeviationNanoseconds": 298.97656831064575,
            "operationsPerSecond": 4370.771000059761
          },
          "gc": {
            "bytesAllocatedPerOperation": 370816,
            "gen0Collections": 363,
            "gen1Collections": 4,
            "gen2Collections": 0
          }
        }
      ]
    }
  ]
}</code></pre>

</details>

