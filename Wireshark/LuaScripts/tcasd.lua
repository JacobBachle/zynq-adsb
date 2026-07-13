-- Define Protocol
local p_tcasd = Proto("TCASD", "TCAS SDR Hardware Protocol")

-- Define Fields matching the 12-byte template
local f_icao    = ProtoField.uint24("tcasd.icao",      "Aircraft ICAO Address",   base.HEX)
local f_status  = ProtoField.uint8("tcasd.status",     "SDR Receiver Status",     base.HEX)
local f_alt     = ProtoField.int32("tcasd.altitude",   "Altitude (ft)",           base.DEC)
local f_range   = ProtoField.uint16("tcasd.range",     "Target Range (nmi/10)",   base.DEC)
local f_bearing = ProtoField.uint16("tcasd.bearing",   "Bearing (deg)",           base.DEC)

p_tcasd.fields = { f_icao, f_status, f_alt, f_range, f_bearing }

-- Main Parser Function
function p_tcasd.dissector(buffer, pinfo, tree)
    -- Enforce absolute minimum constraint check
    if buffer:len() < 12 then return end

    -- Update Wireshark GUI List Panel Columns
    pinfo.cols.protocol = p_tcasd.name
    pinfo.cols.info = "TCAS Target Update"

    -- Create Protocol Details Tree Node
    local subtree = tree:add(p_tcasd, buffer(0, 12), "TCASD Telemetry Frame")

    -- Parse sequential data segments mapping down onto the raw frame bytes
    subtree:add(f_icao,    buffer(0, 3))  
    subtree:add(f_status,  buffer(3, 1))  
    subtree:add(f_alt,     buffer(4, 4))  
    subtree:add(f_range,   buffer(8, 2))  
    subtree:add(f_bearing, buffer(10, 2)) 
end

-- Bind directly to the custom Experimental EtherType
local eth_table = DissectorTable.get("ethertype")
eth_table:add(0x88B5, p_tcasd)