using SFML.Graphics;
using SFML.System;
using yeomensaga.Models.Graphical;

namespace yeomensaga.Models.Logical
{
    public class Map : Drawable
    {
        #region Properties

        public int Width { get; set; }

        public int Height { get; set; }

        public DimetricSprite[,] TerrainLayer { get; set; }

        public DimetricSprite[,] BuildingLayer { get; set; }

        public Vector2f CenterPosition => TerrainLayer[Width/2, Height/2].Position;
        public Vector2f TopCorner => TerrainLayer[0, 0].Position;
        public Vector2f LeftCorner => TerrainLayer[0, Height-1].Position;
        public Vector2f RightCorner => TerrainLayer[Width-1, 0].Position;

        public Vector2f BottomCorner => TerrainLayer[Width-1, Height-1].Position;

        #endregion

        #region Constructors

        public Map()
        {
        }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            TerrainLayer = new DimetricSprite[width, height];
            BuildingLayer = new DimetricSprite[width, height];
        }

        #endregion

        #region Methods

        public void Fill(Texture texture)
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    TerrainLayer[i,j] = new DimetricSprite(texture);
                    TerrainLayer[i,j].WorldPosition = new Vector2f(i, j);
                    TerrainLayer[i,j].Update();
                }
            }
        }

        #endregion

        #region Drawable

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    if (TerrainLayer[i,j] != null)
                    {
                        TerrainLayer[i,j].Update();
                        TerrainLayer[i,j].Draw(target, states);
                    }
                }
            }
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    if (BuildingLayer[i,j] != null)
                    {
                        BuildingLayer[i,j].Update();
                        BuildingLayer[i,j].Draw(target, states);
                    }
                }
            }
        }

        #endregion
    }
}
