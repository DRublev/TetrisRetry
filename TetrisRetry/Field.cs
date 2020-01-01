using System;
using System.Collections.Generic;
using System.Timers;
using TetrisRetry.EventSystem;

namespace TetrisRetry
{
				public partial class Field
				{
								public static void InitFieldEvent(List<String> field)
								{
												CustomEventHandler.Instance.Call("InitFieldEvent", new object[] { field });
								}

								public static void FieldUpdateEvent(List<String> field)
								{
												CustomEventHandler.Instance.Call("FieldUpdateEvent", new object[] { field });
								}
				}

				public partial class Field
				{
								protected FieldEventManager eventManager = new FieldEventManager();

								public Field()
								{
												Init();
								}

								private int height = Config.FIELD_HEIGHT;
								private int width = Config.FIELD_WIDTH;
								private List<String> field = new List<String>();
								private Figure currentFigure = null;

								private void Init()
								{
												String empty = new String('-', width);

												for(int i = 0; i < height; i++)
												{
																field.Add(empty);
												}

												InitFieldEvent(field);
												AddFigure();
												Config.GLOBAL_TIMER.Elapsed += new ElapsedEventHandler(MoveCurrentFigureDown);
								}

								private void AddFigure()
								{
												Figure fig = new Figure();

												List<Coordinates> coords = new List<Coordinates>();

												for(int i = 0; i < fig.figure.Count; i++)
												{
																for(int j = 0; j < fig.figure[0].Length; j++)
																{
																				if(fig.figure[i][j] == Config.FILLING)
																				{
																								int x = ((width - fig.figure[0].Length) / 2) + j;
																								int y = height - i - 1;
																								coords.Add(new Coordinates(x, y));
																				}
																}
												}

												fig.Coords = coords;

												currentFigure = fig;

												AddToField(coords);
												FieldUpdateEvent(field);
								}

								private void AddToField(List<Coordinates> coords, char filling = Config.FILLING)
								{
												for(int i = 0; i < coords.Count; i++)
												{
																char[] row = field[coords[i].y].ToCharArray();
																row[coords[i].x] = filling;
																field[coords[i].y] = new String(row);
												}

												FieldUpdateEvent(field);
								}

								private bool CanMove(List<Coordinates> coordsToCheck)
								{
												bool canMove = true;



												return canMove;
								}

								private void MoveCurrentFigureDown(object sender, ElapsedEventArgs args)
								{
											/*	if(!CanMove(currentFigure.Coords))
												{
																AddFigure();
																return;
												}*/

												List<Coordinates> oldCords = currentFigure.Coords;

												for(int i = 0; i < currentFigure.Coords.Count; i++)
												{
																Coordinates cords = currentFigure.Coords[i];

																if(cords.y - 1 >= 0)
																{
																				char[] row = field[cords.y].ToCharArray();
																				row[cords.x] = ' ';
																				field[cords.y] = new String(row);
																				cords.y--;
																}
																else
																{
																				return;
																}

																currentFigure.Coords[i] = cords;
																
												}
												AddToField(currentFigure.Coords);
								}

								private void Move(Coordinates from, Coordinates to)
								{
												char[] row = field[to.y].ToCharArray();
												row[to.x] = field[from.y][from.x];
												field[to.y] = new String(row);
								}
				}
}
