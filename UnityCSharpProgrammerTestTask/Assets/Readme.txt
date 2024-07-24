Краткое объяснение работы проекта, прочтите, пожалуйста ^_^

Для цепочек загрузки используются стейт-машины. Предусмотрены две реализации: GlobalStateMachine, StateMachine
GlobalStateMachine появляется в самом начале и отвечает за глобальные стейты загрузки.
StateMachine используется как локальная машина и управляет обычно стейтами геймплея.
Для отладки машин состояний можете включить DEBUG_STATE_MACHINE через Tools/Debug
Стандартный процесс загрузки: загрузка сцены (все локальные сервисы сцены будут созданы и инициализированы тут) 
                              -> загрузка ресурсов (все локальные сервисы получат оповещение о загрузке ресурсов)
                              -> переход в локальную машину состояний


порядок загрузки: (bootstrapLoader) -> projInstaller -> bootstrapInstaller -> projLoadState -> hubLoadState -> (local)HubState ->:
                  -> miniGame1LoadState -> (local)miniGame1State
                  -> miniGame1UnloadState
                  -> miniGame2LoadState -> (local)miniGame2State ->:
                                        -> (local)miniGame2WinState
                                        -> (local)miniGame2DefeatState
                  -> miniGame2UnloadState
                  -> (anyWay)projectExitState

Для загрузки ассетов используются сервис AssetLoader, он загружает ассеты по меткам, ссылка на первую метку(Project) передаётся ему через projInstaller
При загрузке, все заинтересованные буду оповещены через IAssetReceiver<> 
Порядок загрузки ассетов: Project -> Hub -> :
                          -> MiniGame1
                          -> MiniGame2
Директория с бандлами: \AppData\LocalLow\Unity\DefaultCompany_UnityCSharpProgrammerTestTask
Предупреждение "AssetBundle 'X' with hash 'Y' is still in use." связано с попыткой выгрузить общий локальный бандл на который есть ссылка у remote бандла 


Система загрузки прогресса тоже использует систему оповещения о загрузке-сохранении прогресса через специальные интерфейсы: IProgressReader, IProgressWriter
порядок загрузки прогресса: miniGame1LoadState(loadProgress) -> miniGame1UnloadState(save progress)
                            miniGame2LoadState(loadProgress) -> miniGame2UnloadState(save progress)
                            (anyWay)projectExitState(save progress) 
                            

зависимости сборок: Common: nothing
                    Hub: Common, MiniGame1, MiniGame2
                    MiniGame1: Common 
                    MiniGame2: Common
