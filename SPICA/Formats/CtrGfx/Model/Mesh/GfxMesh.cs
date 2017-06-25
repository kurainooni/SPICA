﻿using SPICA.Formats.Common;
using SPICA.Serialization.Attributes;

namespace SPICA.Formats.CtrGfx.Model.Mesh
{
    [TypeChoice(0x01000000u, typeof(GfxMesh))]
    public class GfxMesh
    {
        private GfxRevHeader Header;

        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value ?? throw Exceptions.GetNullException("Name");
            }
        }

        public readonly GfxDict<GfxMetaData> MetaData;

        public int ShapeIndex;
        public int MaterialIndex;

        public GfxModel Parent;

        private byte Visible;

        public bool IsVisible
        {
            get
            {
                return Visible != 0;
            }
            set
            {
                Visible = (byte)(value ? 1 : 0);
            }
        }

        public byte RenderPriority;

        public short MeshNodeIndex;

        public int PrimitiveIndex;

        /*
         * Stuff below is filled by game engine with data (see H3DMesh for meaning of those).
         * On the binary model file it's always zero so we can just ignore.
         */
        private uint Flags;

        [Inline, FixedLength(12)] private uint[] AttrScaleCommands;

        private uint EnableCommandsPtr;
        private uint EnableCommandsLength;

        private uint DisableCommandsPtr;
        private uint DisableCommandsLength;

        private string _MeshNodeName;

        public string MeshNodeName
        {
            get
            {
                return _MeshNodeName;
            }
            set
            {
                _MeshNodeName = value ?? throw Exceptions.GetNullException("Name");
            }
        }

        private ulong RenderKeyCache;
        private uint CommandAlloc;

        public GfxMesh()
        {
            MetaData = new GfxDict<GfxMetaData>();
        }
    }
}