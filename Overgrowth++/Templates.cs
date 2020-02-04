using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overgrowth__
{
    // I know it looks gross, but it does the job :x
    static class Templates
    {
        public static string CameraScript =
@"// ===== Required Functions =====
void Init()
{
    
}

void Update()
{
    
}

void FrameSelection(bool increased_distance)
{
    
}

// ===== Optional Functions =====
";

        public static string CharacterScript =
@"// ===== Required Functions =====
bool Init(string character_path)
{
    return true;
}

void Reset()
{
    
}
void SetParameters()
{
    
}

void PostReset()
{
    
}

void ScriptSwap()
{
    
}

void Update(int num_frames)
{
    
}

void UpdatePaused()
{
    
}

void ReceiveMessage(string message)
{
    
}

void SetEnabled(bool is_enabled)
{
    
}

void MovementObjectDeleted(int character_id)
{
    
}

void AttachWeapon(int weapon_item_id)
{
    
}

void AttachMisc(int misc_item_id)
{
    
}

void HandleEditorAttachment(int item_id, int attachment_type, bool is_mirrored)
{
    
}

void NotifyItemDetach(int item_id)
{
    
}

float GetTempHealth()
{
    return 1.0f;
}

void ForceApplied(vec3 force)
{
    
}

void Contact()
{
    
}

void Collided(float posx, float posy, float posz, float impulse, float hardness)
{
    
}

int AboutToBeHitByItem(int item_id)
{
    return 1;
}

void HitByItem(string material, vec3 point_of_impact, int item_id, int impact_type)
{
    
}

int WasHit(string type, string attack_path, vec3 dir, vec3 pos, int attacker_id, float attack_damage_mult, float attack_knockback_mult)
{
    return 1;
}

void HandleCollisionsBetweenTwoCharacters(MovementObject@ other_character)
{
    
}

void PreDrawFrame(float curr_game_time)
{
    
}

void PreDrawCameraNoCull(float curr_game_time)
{
    
}

void PreDrawCamera(float curr_game_time)
{
    
}

void DisplayMatrixUpdate()
{
    
}

void FinalAnimationMatrixUpdate(int num_frames)
{
    
}

void FinalAttachedItemUpdate(int num_frames)
{
    
}

void HandleAnimationEvent(string event, vec3 world_pos)
{
    
}

void WasBlocked()
{
    
}

// ===== Optional Functions =====
void Dispose()
{
    
}

void ResetWaypointTarget()
{
    
}
";

        public static string HotspotScript =
@"// ===== Required Functions =====

// ===== Optional Functions =====
string GetTypeString()
{
    return ""MyHotspotType"";
}

void Init()
{
    
}

void SetParameters()
{
    
}

void SetEnabled(bool is_enabled)
{
    
}

void Reset()
{
    
}

void Dispose()
{
    
}

void Update()
{
    
}

void HandleEvent(string event, MovementObject @mo)
{
    
}

void HandleEventItem(string event, ItemObject @obj)
{
    
}

void ReceiveMessage(string message)
{
    
}

void PreDraw(float curr_game_time)
{
    
}

void Draw()
{
    
}

void DrawEditor()
{
    
}
";

    public static string LevelScript =
@"// ===== Required Functions =====
void Init(string level_name)
{
    
}

// ===== Optional Functions =====
void Update(int is_paused)
{
    
}

void Update()
{
    
}

void ReceiveMessage(string message)
{
    
}

void HotspotExit(string str, MovementObject @mo)
{
    
}

void HotspotEnter(string str, MovementObject @mo)
{
    
}

void DrawGUI()
{
    
}

bool HasFocus()
{
    return false;
}

void SetWindowDimensions(int width, int height)
{
    
}

void SaveHistoryState(SavedChunk@ chunk)
{
    
}

void ReadChunk(SavedChunk@ chunk)
{
    
}

void IncomingTCPData(uint socket, array<uint8>@ data)
{
    
}

void DrawGUI2()
{
    
}

void DrawGUI3()
{
    
}

bool DialogueCameraControl()
{
    return false;
}
";
    }
}
